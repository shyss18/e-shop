using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Domain.Entities;
using ES.ProductService.Infrastructure.Models;
using ES.ProductService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ES.ProductService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Agent>, GenericRepository<Agent, AgentModel>>();
        services.AddScoped<IGenericRepository<Product>, GenericRepository<Product, ProductModel>>();
        
        return services;
    }
}