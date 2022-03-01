using MediatR;
using Microsoft.Extensions.Logging;

namespace ES.ProductService.Application.PipelineBehavior;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var requestName = request.GetType().Name;
        _logger.LogInformation($"Start processing request := {requestName}");
        var response = await next();

        _logger.LogInformation($"Finish processing request := {requestName}");

        return response;
    }
}