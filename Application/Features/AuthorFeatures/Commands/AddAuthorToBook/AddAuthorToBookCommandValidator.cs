using FluentValidation;

namespace Application.Features.AuthorFeatures.Commands.AddAuthorToBook;

public class AddAuthorToBookCommandValidator : AbstractValidator<AddAuthorToBookCommand>
{
    public AddAuthorToBookCommandValidator()
    {
        RuleFor(c => c.AuthorId)
            .NotEmpty().WithMessage("AuthorId is required.");
        RuleFor(c => c.BookId)
            .NotEmpty().WithMessage("BookId is required.");
    }
}