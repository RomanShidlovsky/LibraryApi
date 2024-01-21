using FluentValidation;

namespace Application.Features.GenreFeatures.Commands.Create;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(g => g.Name)
            .NotEmpty()
            .MaximumLength(15);
    }
}