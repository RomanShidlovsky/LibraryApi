using FluentValidation;

namespace Application.Features.AuthorFeatures.Queries.GetById;

public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
{
    public GetAuthorByIdQueryValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty();
    }
}