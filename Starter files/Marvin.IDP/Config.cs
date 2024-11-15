﻿using Duende.IdentityServer;
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
                new IdentityResource(
                    name: "roles",
                    displayName: "Your role(s)",
                    userClaims: ["role"]),
                new IdentityResource(
                    name: "country",
                    displayName: "The country you're living in",
                    userClaims: ["country"])
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource(
                    name: "imagegalleryapi", 
                    displayName: "Image Gallery API",
                    userClaims: ["role", "country"])
                {
                    Scopes = { 
                        "imagegalleryapi.fullaccess",
                        "imagegalleryapi.read",
                        "imagegalleryapi.write"
                    },
                    ApiSecrets = { new Secret("apisecret".Sha256()) }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("imagegalleryapi.fullaccess"),
                new ApiScope("imagegalleryapi.read"),
                new ApiScope("imagegalleryapi.write")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
                {
                    new()
                    {
                        ClientName = "Image Galllery",
                        ClientId = "imagegalleryclient",
                        AllowedGrantTypes = GrantTypes.Code,
                        AllowOfflineAccess = true,
                        IdentityTokenLifetime = 300, // 5 minutes
                        AuthorizationCodeLifetime = 300, // 5 minutes
                        AccessTokenLifetime = 120, // defaults to 3.600 = 1h
                        AbsoluteRefreshTokenLifetime = 2592000, // 30 days
                        //RefreshTokenExpiration = TokenExpiration.Sliding,
                        //SlidingRefreshTokenLifetime = 3600,
                        UpdateAccessTokenClaimsOnRefresh = true,
                        //AccessTokenType = AccessTokenType.Jwt,
                        AccessTokenType = AccessTokenType.Reference,
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
                            //"imagegalleryapi.fullaccess",
                            "imagegalleryapi.read",
                            "imagegalleryapi.write",
                            "country"
                        },
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        RequireConsent = true
                    },
                    new()
                    {
                        ClientName = "Image Galllery BFF",
                        ClientId = "imagegallerybff",
                        AllowedGrantTypes = GrantTypes.Code,
                        AllowOfflineAccess = true,
                        IdentityTokenLifetime = 300, // 5 minutes
                        AuthorizationCodeLifetime = 300, // 5 minutes
                        AccessTokenLifetime = 120, // defaults to 3.600 = 1h
                        AbsoluteRefreshTokenLifetime = 2592000, // 30 days
                        //RefreshTokenExpiration = TokenExpiration.Sliding,
                        //SlidingRefreshTokenLifetime = 3600,
                        UpdateAccessTokenClaimsOnRefresh = true,
                        //AccessTokenType = AccessTokenType.Jwt,
                        AccessTokenType = AccessTokenType.Reference,
                        RedirectUris =
                        {
                            "https://localhost:7119/signin-oidc"
                        },
                        PostLogoutRedirectUris =
                        {
                            "https://localhost:7119/signout-callback-oidc"
                        },
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "roles",
                            //"imagegalleryapi.fullaccess",
                            "imagegalleryapi.read",
                            "imagegalleryapi.write",
                            "country"
                        },
                        ClientSecrets =
                        {
                            new Secret("anothersecret".Sha256())
                        },
                        RequireConsent = true
                    }
                };
    }
}