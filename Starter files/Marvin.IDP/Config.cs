using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Marvin.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(name: "roles",
                    displayName: "Your role(s)",
                    userClaims: new [] { "role" })
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("imagegalleryapi", "Image Galiry API")
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[]
                {
                    new()
                    {
                        ClientName = "Image Galllery",
                        ClientId = "imagegalleryclient",
                        AllowedGrantTypes = GrantTypes.Code,
                        RedirectUris =
                        {
                            "https://localhost:7184/signin-oidc"
                        },
                        PostLogoutRedirectUris =
                        {
                            "https://localhost:7184/signout-callback-oidc"
                        },
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "roles",
                            "imagegalleryapi"
                        },
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        RequireConsent = true
                    }
                };
    }
}