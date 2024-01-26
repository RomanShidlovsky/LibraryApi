using FluentValidation;

namespace Application.Features.GenreFeatures.Queries.GetById;

public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
{
    public GetGenreByIdQueryValidator()
    {
        RuleFor(b => b.Id)
            .NotEmpty().WithMessage("The Id field is required.");
    }
}