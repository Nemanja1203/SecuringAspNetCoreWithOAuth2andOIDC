// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using System.Security.Claims;
using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;
using IdentityModel;
using Marvin.IDP.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marvin.IDP.Pages.ExternalLogin;

[AllowAnonymous]
[SecurityHeaders]
public class Callback : PageModel
{
    private readonly IIdentityServerInteractionService _interaction;
    private readonly ILogger<Callback> _logger;
    private readonly IEventService _events;
    private readonly ILocalUserService _localUserService;

    private readonly Dictionary<string, string> _facebookClaimTypeMap = new()
    {
        { 
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname",
            JwtClaimTypes.GivenName
        },
        {
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname",
            JwtClaimTypes.FamilyName
        },
        {
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress",
            JwtClaimTypes.Email
        }
    };

    public Callback(
        IIdentityServerInteractionService interaction,
        IEventService events,
        ILogger<Callback> logger,
        ILocalUserService localUserService)
    {
        // this is where you would plug in your own custom identity management library (e.g. ASP.NET Identity)
 
        _interaction = interaction;
        _logger = logger;
        _localUserService = localUserService;
        _events = events;
    }
        
    public async Task<IActionResult> OnGet()
    {
        // read external identity from the temporary cookie
        var result = await HttpContext.AuthenticateAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);
        if (result.Succeeded != true)
        {
            throw new InvalidOperationException($"External authentication error: { result.Failure }");
        }

        var externalUser = result.Principal ?? 
            throw new InvalidOperationException("External authentication produced a null Principal");
		
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            var externalClaims = externalUser.Claims.Select(c => $"{c.Type}: {c.Value}");
            _logger.ExternalClaims(externalClaims);
        }

        // lookup our user and external provider info
        // try to determine the unique id of the external user (issued by the provider)
        // the most common claim type for that are the sub claim and the NameIdentifier
        // depending on the external provider, some other claim type might be used
        var userIdClaim = externalUser.FindFirst(JwtClaimTypes.Subject) ??
                          externalUser.FindFirst(ClaimTypes.NameIdentifier) ??
                          throw new InvalidOperationException("Unknown userid");

        var provider = result.Properties.Items["scheme"] 
            ?? throw new InvalidOperationException("Null scheme in authentiation properties");
        var providerUserId = userIdClaim.Value;

        // find external user
        var user = await _localUserService.FindUserByExternalProviderAsync(provider, providerUserId);
        if (user == null)
        {
            // remove the userId claim: that information is stored in the UserLogin table
            var claims = externalUser.Claims.ToList();
            claims.Remove(userIdClaim);

            var mappedClaims = new List<Claim>();
            // map the claims, and ignore those for which no mapping exists
            foreach (var claim in claims)
            {
                //if (provider = "Facebook")
                if (_facebookClaimTypeMap.ContainsKey(claim.Type))
                {
                    mappedClaims.Add(new Claim(_facebookClaimTypeMap[claim.Type], claim.Value));
                }
            }

            // we need additional claims like: rola claim and country claim
            // we could ask for that by adding an additional view (lige Registration view)

            // hardcoding values so we can continue
            mappedClaims.Add(new Claim("role", "FreeUser"));
            mappedClaims.Add(new Claim("country", "be"));

            // auto-provision the user
            _localUserService.AutoProvisionUser(provider, providerUserId, mappedClaims.ToList());
            await _localUserService.SaveChangesAsync();
        }

        // this allows us to collect any additional claims or properties
        // for the specific protocols used and store them in the local auth cookie.
        // this is typically used to store data needed for signout from those protocols.
        var additionalLocalClaims = new List<Claim>();
        var localSignInProps = new AuthenticationProperties();
        CaptureExternalLoginContext(result, additionalLocalClaims, localSignInProps);
            
        // issue authentication cookie for user
        var isuser = new IdentityServerUser(user.Subject)
        {
            DisplayName = user.UserName,
            IdentityProvider = provider,
            AdditionalClaims = additionalLocalClaims
        };

        await HttpContext.SignInAsync(isuser, localSignInProps);

        // delete temporary cookie used during external authentication
        await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

        // retrieve return URL
        var returnUrl = result.Properties.Items["returnUrl"] ?? "~/";

        // check if external login is in the context of an OIDC request
        var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
        await _events.RaiseAsync(
            new UserLoginSuccessEvent(
                provider: provider,
                providerUserId: providerUserId,
                subjectId: user.Subject,
                name: user.UserName,
                interactive: true,
                clientId: context?.Client.ClientId));
        Telemetry.Metrics.UserLogin(context?.Client.ClientId, provider!);

        if (context != null)
        {
            if (context.IsNativeClient())
            {
                // The client is native, so this change in how to
                // return the response is for better UX for the end user.
                return this.LoadingPage(returnUrl);
            }
        }

        return Redirect(returnUrl);
    }

    // if the external login is OIDC-based, there are certain things we need to preserve to make logout work
    // this will be different for WS-Fed, SAML2p or other protocols
    private static void CaptureExternalLoginContext(AuthenticateResult externalResult, List<Claim> localClaims, AuthenticationProperties localSignInProps)
    {
        ArgumentNullException.ThrowIfNull(externalResult.Principal, nameof(externalResult.Principal));

        // capture the idp used to login, so the session knows where the user came from
        localClaims.Add(new Claim(JwtClaimTypes.IdentityProvider, externalResult.Properties?.Items["scheme"] ?? "unknown identity provider"));

        // if the external system sent a session id claim, copy it over
        // so we can use it for single sign-out
        var sid = externalResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.SessionId);
        if (sid != null)
        {
            localClaims.Add(new Claim(JwtClaimTypes.SessionId, sid.Value));
        }

        // if the external provider issued an id_token, we'll keep it for signout
        var idToken = externalResult.Properties?.GetTokenValue("id_token");
        if (idToken != null)
        {
            localSignInProps.StoreTokens(new[] { new AuthenticationToken { Name = "id_token", Value = idToken } });
        }
    }
}
