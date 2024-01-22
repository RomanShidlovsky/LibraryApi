using FluentValidation;

namespace Application.Features.SubscriptionFeatures.Commands.Create;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(s => s.BookId).NotEmpty();
        RuleFor(s => s.UserId).NotEmpty();
        RuleFor(s => s.ShouldReturnAt).GreaterThan(DateTime.UtcNow);
    }
}