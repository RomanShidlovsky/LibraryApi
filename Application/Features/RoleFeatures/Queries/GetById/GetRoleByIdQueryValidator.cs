using System.Data;
using Application.Features.GenreFeatures.Queries.GetById;
using FluentValidation;

namespace Application.Features.RoleFeatures.Queries.GetById;

public class GetRoleByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("Genre Id is required.");
    }
}