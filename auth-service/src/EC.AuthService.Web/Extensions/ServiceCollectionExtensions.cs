using EC.AuthService.Web.Configurations;
using EC.AuthService.Web.IS4Configurations;

namespace EC.AuthService.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureIdentityServer(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddIdentityServer(options =>
            {
                options.IssuerUri = configuration["IdentityServer:IssuerUri"];
                options.UserInteraction.LoginUrl = configuration["IdentityServer:LoginUrl"];
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.Events.RaiseInformationEvents = true;
            })
            .AddInMemoryIdentityResources(IdentityResources.Get)
            .AddInMemoryApiScopes(ApiScopes.Get)
            .AddInMemoryClients(Clients.Get(configuration.Get<ClientsConfiguration>()));

        return services;
    }
}