using FluentValidation;

namespace Application.Features.BookFeatures.Queries.GetById;

public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(b => b.Id).NotEmpty();
    }
}