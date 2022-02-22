using ES.ProductService.Application.Commands.CreateProduct;
using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Application.PipelineBehavior;
using ES.ProductService.Domain.Entities;
using ES.ProductService.Infrastructure.Context;
using ES.ProductService.Infrastructure.Migrations;
using ES.ProductService.Infrastructure.Models;
using ES.ProductService.Infrastructure.Repositories;
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
        var connectionString = configurationManager.GetConnectionString(ApplicationContext.ConnectionString);

        services.AddScoped<IGenericRepository<Agent>, GenericRepository<Agent, AgentModel>>();
        services.AddScoped<IGenericRepository<Product>, GenericRepository<Product, ProductModel>>();

        services.AddTransient<IMigrationApplier, MigrationApplier>();

        services.AddDbContext<ApplicationContext>(opt =>
            opt.UseNpgsql(connectionString, x => x.MigrationsAssembly(ApplicationContext.MigrationAssembly)));

        return services;
    }
}