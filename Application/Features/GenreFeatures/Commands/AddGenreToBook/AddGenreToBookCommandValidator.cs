using FluentValidation;

namespace Application.Features.GenreFeatures.Commands.AddGenreToBook;

public class AddGenreToBookCommandValidator : AbstractValidator<AddGenreToBookCommand>
{
    public AddGenreToBookCommandValidator()
    {
        RuleFor(c => c.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(c => c.GenreId)
            .NotEmpty().WithMessage("GenreId is required.");
    }
}