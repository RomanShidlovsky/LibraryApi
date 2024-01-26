using FluentValidation;

namespace Application.Features.GenreFeatures.Commands.Create;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(g => g.Name)
            .NotEmpty().WithMessage("Genre Name is required.")
            .MaximumLength(15).WithMessage("Genre Name must not exceed 15 characters.");
    }
}