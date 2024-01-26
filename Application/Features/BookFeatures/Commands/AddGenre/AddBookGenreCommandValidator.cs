using FluentValidation;

namespace Application.Features.BookFeatures.Commands.AddGenre;

public class AddBookGenreCommandValidator : AbstractValidator<AddBookGenreCommand>
{
    public AddBookGenreCommandValidator()
    {
        RuleFor(c => c.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(c => c.GenreId)
            .NotEmpty().WithMessage("GenreId is required.");
    }
}