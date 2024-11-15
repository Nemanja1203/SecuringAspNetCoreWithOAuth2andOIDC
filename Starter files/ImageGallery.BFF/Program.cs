using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(configure =>
        configure.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddHttpClient("IDPClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/");
});

JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

// IMPORTANT:
const string bffCookieScheme = "BFFCookieScheme";
const string bffChallengeScheme = "BFFChallengeScheme";

// Registers required services for access token management
//builder.Services.AddAccessTokenManagement();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = bffCookieScheme; //CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = bffChallengeScheme; //OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(bffCookieScheme)
    //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    //{
    //    options.AccessDeniedPath = "/Authentication/AccessDenied"; // Path should start with a forward slash
    //})
    .AddOpenIdConnect(bffChallengeScheme, options =>
    {
        options.SignInScheme = bffCookieScheme; //CookieAuthenticationDefaults.AuthenticationScheme;
        options.Authority = "https://localhost:5001/"; // Address of our Identity Provider
        options.ClientId = "imagegallerybff"; // Should match cliend id on the level of Identity Provider
        options.ClientSecret = "anothersecret"; // Should match secret we configured on the level of Identity Provider
        options.ResponseType = "code";

        //options.Scope.Add("openid"); // By default openid and profile scopes are requested by the middleware
        //options.Scope.Add("profile");
        options.Scope.Add("roles");
        //options.Scope.Add("imagegalleryapi.fullaccess");
        options.Scope.Add("imagegalleryapi.read");
        options.Scope.Add("imagegalleryapi.write");
        options.Scope.Add("country");
        options.Scope.Add("offline_access");

        //options.CallbackPath = new PathString("signin-oidc"); // Set up by default

        // SignedOutCallbackPath: default = host:port/signout-callback-oidc.
        // Must match with the post logout redirect URI at IDP client ocnfig if
        // you want to automatically return to the application after logging out
        // of IdentityServer.
        // To change, set SignedOutCallbackPath
        // eg: SignedOutCallbackPath = "pathaftersighout"
        //options.SignedOutCallbackPath = new PathString("signout-callback-oidc"); // This is default value
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClaimActions.Remove("aud"); // Removing filter that removes aud claim from Claims Identity (aud will be present now)
        options.ClaimActions.DeleteClaim("sid");
        options.ClaimActions.DeleteClaim("idp");
        options.ClaimActions.MapJsonKey("role", "role");
        options.ClaimActions.MapUniqueJsonKey("country", "country");

        options.TokenValidationParameters = new()
        {
            NameClaimType = "given_name",
            RoleClaimType = "role"
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
