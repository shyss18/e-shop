using IdentityServer4.Models;

namespace EC.AuthService.Api.Clients;

public static class Clients
{
    public static IEnumerable<Client> Get =>
        new[]
        {
            new Client
            {
                ClientId = "product.service"
            },
            new Client
            {
                ClientId = "price.service"
            },
            new Client
            {
                ClientId = "chat.service"
            },
            new Client
            {
                ClientId = "payment.service"
            },
            new Client
            {
                ClientId = "notification.service"
            }
        };
}