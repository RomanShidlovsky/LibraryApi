using FluentValidation;

namespace Application.Features.SubscriptionFeatures.Commands.Create;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(s => s.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(s => s.UserId)
            .NotEmpty().WithMessage("UserId is required.");
        RuleFor(s => s.ShouldReturnAt)
            .GreaterThan(DateTime.UtcNow).WithMessage("ShouldReturnAt must be greater than the current UTC time.");
    }
}