using FluentValidation;

namespace Application.Features.BookFeatures.Commands.AddAuthor;

public class AddBookAuthorCommandValidator : AbstractValidator<AddBookAuthorCommand>
{
    public AddBookAuthorCommandValidator()
    {
        RuleFor(c => c.AuthorId)
            .NotEmpty().WithMessage("AuthorId is required.");
        RuleFor(c => c.BookId)
            .NotEmpty().WithMessage("BookId is required.");
    }
}