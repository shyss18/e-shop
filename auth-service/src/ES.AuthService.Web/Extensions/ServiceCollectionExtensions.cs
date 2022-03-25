using EC.AuthService.Domain.Models;
using ES.AuthService.Infrastructure;
using ES.AuthService.Web.Configurations;
using ES.AuthService.Web.IS4Configurations;
using Microsoft.AspNetCore.Identity;

namespace ES.AuthService.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureIdentityServer(this IServiceCollection services,
        IConfiguration configuration)
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
            .AddAspNetIdentity<EsIdentityUser>()
            .AddInMemoryIdentityResources(IdentityResources.Get)
            .AddInMemoryApiScopes(ApiScopes.Get)
            .AddInMemoryClients(Clients.Get(configuration.Get<ClientsConfiguration>()));

        services.AddAuthentication();

        return services;
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddIdentity<EsIdentityUser, EsIdentityUserRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}