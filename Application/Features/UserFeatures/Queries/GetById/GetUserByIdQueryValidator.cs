using FluentValidation;

namespace Application.Features.UserFeatures.Queries.GetById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty().WithMessage("User Id is required.");
    }
}