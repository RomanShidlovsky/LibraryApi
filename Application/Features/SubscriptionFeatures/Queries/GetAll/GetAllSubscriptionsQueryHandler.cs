using Application.DTOs.Subscription;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;

namespace Application.Features.SubscriptionFeatures.Queries.GetAll;

public class GetAllSubscriptionsQueryHandler(
    ISubscriptionRepository repository,
    IMapper mapper)
    : IQueryHandler<GetAllSubscriptionsQuery, IEnumerable<SubscriptionViewModel>>
{
    public async Task<Response<IEnumerable<SubscriptionViewModel>>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var subscriptionsList = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<List<SubscriptionViewModel>>(subscriptionsList);
    }
}