using FluentValidation;

namespace Application.Features.SubscriptionFeatures.Queries.GetById;

public class GetSubscriptionByIdQueryValidator : AbstractValidator<GetSubscriptionByIdQuery>
{
    public GetSubscriptionByIdQueryValidator()
    {
        RuleFor(s => s.Id).NotEmpty();
    }
}