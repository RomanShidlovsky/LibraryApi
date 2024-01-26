using FluentValidation;

namespace Application.Features.BookFeatures.Commands.DeleteGenre;

public class DeleteBookGenreCommandValidator : AbstractValidator<DeleteBookGenreCommand>
{
    public DeleteBookGenreCommandValidator()
    {
        RuleFor(c => c.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(c => c.GenreId)
            .NotEmpty().WithMessage("GenreId is required.");
    }
}