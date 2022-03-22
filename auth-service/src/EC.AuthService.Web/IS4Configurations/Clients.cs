using EC.AuthService.Web.Configurations;
using IdentityServer4;
using IdentityServer4.Models;

namespace EC.AuthService.Web.IS4Configurations;

public static class Clients
{
    public static IEnumerable<Client> Get(ClientsConfiguration configuration) =>
        new[]
        {
            new Client
            {
                ClientId = "product.service",
                ClientSecrets = { new Secret("product.service".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = configuration.Clients["product.service"].RedirectUris,
                PostLogoutRedirectUris = configuration.Clients["product.service"].PostLogoutRedirectUris,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "product-api"
                }
            },
            new Client
            {
                ClientId = "price.service",
                ClientSecrets = { new Secret("price.service".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                //TODO:RedirectUris = { "https://localhost:5002/signin-oidc" },
                //TODO:PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "price-api"
                }
            },
            new Client
            {
                ClientId = "chat.service",
                ClientSecrets = { new Secret("chat.service".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = configuration.Clients["chat.service"].RedirectUris,
                PostLogoutRedirectUris = configuration.Clients["chat.service"].PostLogoutRedirectUris,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "chat-api"
                }
            },
            new Client
            {
                ClientId = "payment.service",
                ClientSecrets = { new Secret("payment.service".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                //TODO:RedirectUris = { "https://localhost:5002/signin-oidc" },
                //TODO:PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "payment-api"
                }
            },
            new Client
            {
                ClientId = "notification.service",
                ClientSecrets = { new Secret("notification.service".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                //TODO:RedirectUris = { "https://localhost:5002/signin-oidc" },
                //TODO:PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "notification-api"
                }
            }
        };
}