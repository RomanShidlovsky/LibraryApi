using FluentValidation;

namespace Application.Features.BookFeatures.Commands.DeleteAuthor;

public class DeleteBookAuthorValidator : AbstractValidator<DeleteBookAuthorCommand>
{
    public DeleteBookAuthorValidator()
    {
        RuleFor(c => c.AuthorId)
            .NotEmpty().WithMessage("AuthorId is required.");
        RuleFor(c => c.BookId)
            .NotEmpty().WithMessage("BookId is required.");
    }
}