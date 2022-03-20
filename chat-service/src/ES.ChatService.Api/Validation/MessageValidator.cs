using ES.ChatService.Domain.Models;
using FluentValidation;

namespace ES.ChatService.Api.Validation;

public class MessageValidator : AbstractValidator<Message>
{
    public MessageValidator()
    {
        RuleFor(x => x.Text).NotNull().WithMessage("Text property is required");
        RuleFor(x => x.From).NotNull().NotEmpty().WithMessage("From property is required");
        RuleFor(x => x.To).NotNull().NotEmpty().WithMessage("To property is required");
    }
}