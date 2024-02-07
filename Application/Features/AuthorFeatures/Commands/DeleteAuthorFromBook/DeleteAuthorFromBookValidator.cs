using FluentValidation;

namespace Application.Features.AuthorFeatures.Commands.DeleteAuthorFromBook;

public class DeleteAuthorFromBookValidator : AbstractValidator<DeleteAuthorFromBookCommand>
{
    public DeleteAuthorFromBookValidator()
    {
        RuleFor(c => c.AuthorId)
            .NotEmpty().WithMessage("AuthorId is required.");
        RuleFor(c => c.BookId)
            .NotEmpty().WithMessage("BookId is required.");
    }
}