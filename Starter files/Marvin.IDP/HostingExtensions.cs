using Marvin.IDP.DbContexts;
using Marvin.IDP.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Duende.IdentityServer;

namespace Marvin.IDP
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // configures IIS out-of-proc settings
            builder.Services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });
            // ..or configures IIS in-proc settings
            builder.Services.Configure<IISServerOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            // uncomment if you want to add a UI
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<ILocalUserService, LocalUserService>();
            builder.Services.AddScoped<IPasswordHasher<Entities.User>, PasswordHasher<Entities.User>>();

            builder.Services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlite(
                    builder.Configuration["ConnectionStrings:MarvinIdentityDBConnectionString"]);
            });

            builder.Services.AddIdentityServer(options =>
                {
                    // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                    options.EmitStaticAudienceClaim = true;
                })
                .AddProfileService<LocalUserProfileService>() // Transient
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients);

            builder.Services
                .AddAuthentication()
                .AddOpenIdConnect(
                    authenticationScheme: "AAD", 
                    displayName: "Azure Active Directory (Entra)...", 
                    options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme; // "idsrv.external"
                        options.Authority = "https://login.microsoftonline.com/1a18d5f5-4e6c-44e2-afa2-4054f1113e1b/v2.0"; // Address of our Identity Provider
                        options.ClientId = "9af802c1-32a6-40c8-99f5-15d367e59814"; // Should match cliend id on the level of Identity Provider
                        options.ClientSecret = "secret-goes-here"; // Should match secret we configured on the level of Identity Provider
                        options.ResponseType = "code";
                        options.CallbackPath = new PathString("/signin-aad/");
                        options.SignedOutCallbackPath = new PathString("/signout-aad/");
                        options.Scope.Add("email");
                        options.Scope.Add("offline_access");
                        options.SaveTokens = true;
                    });

            builder.Services
                .AddAuthentication()
                .AddFacebook(
                    authenticationScheme: "Facebook",
                    options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                        options.AppId = "1283327816432909";
                        options.AppSecret = "secret-goes-here";
                    });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to add a UI
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment if you want to add a UI
            app.UseAuthorization();
            app.MapRazorPages().RequireAuthorization();

            return app;
        }
    }
}
