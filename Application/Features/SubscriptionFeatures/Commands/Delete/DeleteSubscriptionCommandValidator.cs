using FluentValidation;

namespace Application.Features.SubscriptionFeatures.Commands.Delete;

public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
{
    public DeleteSubscriptionCommandValidator()
    {
        RuleFor(s => s.Id).NotEmpty();
    }
}