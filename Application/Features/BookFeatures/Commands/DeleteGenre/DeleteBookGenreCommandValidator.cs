using FluentValidation;

namespace Application.Features.BookFeatures.Commands.DeleteGenre;

public class DeleteBookGenreCommandValidator : AbstractValidator<DeleteBookGenreCommand>
{
    public DeleteBookGenreCommandValidator()
    {
        RuleFor(c => c.BookId).NotEmpty();
        RuleFor(c => c.GenreId).NotEmpty();
    }
}