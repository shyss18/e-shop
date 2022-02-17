using ES.ProductService.Application.Commands.ChangeProduct;
using FluentValidation;

namespace ES.ProductService.Application.Validators;

public class ChangeProductValidator : AbstractValidator<ChangeProductCommand>
{
    public ChangeProductValidator()
    {
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.Description).NotNull().NotEmpty();
        RuleFor(x => x.Name).NotNull().NotEmpty();
    }
}