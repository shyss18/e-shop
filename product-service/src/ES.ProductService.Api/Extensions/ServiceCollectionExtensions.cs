using ES.ProductService.Application.Commands.CreateProduct;
using ES.ProductService.Application.PipelineBehavior;
using ES.ProductService.Infrastructure.Context;
using ES.ProductService.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ES.ProductService.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediatrSupport(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateProductCommand));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        return services;
    }

    public static IServiceCollection AddDbSupport(
        this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        services
            .AddRepositories()
            .AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(configurationManager.GetConnectionString("ApplicationContext")));
        return services;
    }
}