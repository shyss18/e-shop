using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ES.ProductService.Application.PipelineBehavior;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(
        IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
            return await next();

        var validationContext = new ValidationContext<TRequest>(request);
        var failures = new List<ValidationFailure>();
        foreach (var validator in _validators)
        {
            ValidationResult result = await validator.ValidateAsync(validationContext, cancellationToken);
            if (!result.IsValid) failures.AddRange(result.Errors);
        }

        if (failures.Any())
            throw new ValidationException(failures);

        return await next();
    }
}