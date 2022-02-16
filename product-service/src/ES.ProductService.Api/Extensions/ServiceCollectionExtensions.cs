using ES.ProductService.Infrastructure.Context;
using ES.ProductService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace ES.ProductService.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbSupport(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(configurationManager.GetConnectionString("ApplicationContext")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}