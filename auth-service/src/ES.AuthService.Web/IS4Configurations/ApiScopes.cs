using IdentityServer4.Models;

namespace ES.AuthService.Web.IS4Configurations;

public static class ApiScopes
{
    public static IEnumerable<ApiScope> Get
        => new[]
        {
            new ApiScope("product-api", "Manage products"),
            new ApiScope("price-api", "Calculate prices based on local information"),
            new ApiScope("payment-api", "Provide 3rd-party library for purchase"),
            new ApiScope("chat-api", "Chat between two clients"),
            new ApiScope("notification-api",
                "Send notifications about purchase, updating subscription notification")
        };
}