using IdentityServer4.Models;

namespace EC.AuthService.Web.IS4Configurations;

public static class IdentityResources
{
    public static IEnumerable<IdentityResource> Get =>
        new IdentityResource[]
        {
            new IdentityServer4.Models.IdentityResources.OpenId(),
            new IdentityServer4.Models.IdentityResources.Profile()
        };
}