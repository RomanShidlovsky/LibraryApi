using FluentValidation;

namespace Application.Features.BookFeatures.Commands.DeleteAuthor;

public class DeleteBookAuthorValidator : AbstractValidator<DeleteBookAuthorCommand>
{
    public DeleteBookAuthorValidator()
    {
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.BookId).NotEmpty();
    }
}