using FluentValidation;

namespace Application.Features.GenreFeatures.Commands.DeleteGenreFromBook;

public class DeleteGenreFromBookCommandValidator : AbstractValidator<DeleteGenreFromBookCommand>
{
    public DeleteGenreFromBookCommandValidator()
    {
        RuleFor(c => c.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(c => c.GenreId)
            .NotEmpty().WithMessage("GenreId is required.");
    }
}