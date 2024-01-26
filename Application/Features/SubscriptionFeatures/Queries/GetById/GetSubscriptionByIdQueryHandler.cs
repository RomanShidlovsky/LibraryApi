using Application.DTOs.Subscription;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.SubscriptionFeatures.Queries.GetById;

public class GetSubscriptionByIdQueryHandler(
    ISubscriptionRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetSubscriptionByIdQuery, SubscriptionViewModel>
{
    public async Task<Response<SubscriptionViewModel>> Handle(GetSubscriptionByIdQuery request,
        CancellationToken cancellationToken)
    {
        var subscription = await repository.GetByIdAsync(request.Id, cancellationToken);

        return subscription == null
            ? Response.Failure<SubscriptionViewModel>(DomainErrors.Subscription.SubscriptionNotFoundById)
            : mapper.Map<SubscriptionViewModel>(subscription);
    }
}