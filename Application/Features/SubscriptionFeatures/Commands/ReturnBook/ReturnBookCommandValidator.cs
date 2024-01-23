using FluentValidation;

namespace Application.Features.SubscriptionFeatures.Commands.ReturnBook;

public class ReturnBookCommandValidator : AbstractValidator<ReturnBookCommand>
{
    public ReturnBookCommandValidator()
    {
        RuleFor(r => r.BookId).NotEmpty();
    }
}