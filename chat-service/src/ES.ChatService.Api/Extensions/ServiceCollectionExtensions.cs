using ES.ChatService.Api.Validation;
using ES.ChatService.Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ES.ChatService.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidation();
        services.AddTransient<IValidator<Message>, MessageValidator>();
        
        return services;
    }
}