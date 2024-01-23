using FluentValidation;

namespace Application.Features.BookFeatures.Commands.AddAuthor;

public class AddBookAuthorCommandValidator : AbstractValidator<AddBookAuthorCommand>
{
    public AddBookAuthorCommandValidator()
    {
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.BookId).NotEmpty();
    }
}