using FluentValidation;

namespace Application.Features.GenreFeatures.Commands.Update;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(g => g.Id)
            .NotEmpty().WithMessage("Genre Id is required.");

        RuleFor(g => g.Name)
            .NotEmpty().WithMessage("GenreName is required.")
            .MaximumLength(15).WithMessage("GenreName must not exceed 15 characters.");
    }
}