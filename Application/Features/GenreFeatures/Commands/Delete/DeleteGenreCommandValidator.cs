using FluentValidation;

namespace Application.Features.GenreFeatures.Commands.Delete;

public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(g => g.Id)
            .NotEmpty().WithMessage("The id field is required.");
    }
}