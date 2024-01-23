using FluentValidation;

namespace Application.Features.BookFeatures.Commands.AddGenre;

public class AddBookGenreCommandValidator : AbstractValidator<AddBookGenreCommand>
{
    public AddBookGenreCommandValidator()
    {
        RuleFor(c => c.BookId).NotEmpty();
        RuleFor(c => c.GenreId).NotEmpty();
    }
}