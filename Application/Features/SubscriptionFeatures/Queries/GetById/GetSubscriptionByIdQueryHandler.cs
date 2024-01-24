using Application.DTOs.Subscription;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.SubscriptionFeatures.Queries.GetById;

public class GetSubscriptionByIdQueryHandler(
    ISubscriptionRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetSubscriptionByIdQuery, SubscriptionViewModel>
{
    public async Task<Response<SubscriptionViewModel>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var subscription = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (subscription == null)
            return new NotFoundException(request.Id, typeof(Subscription));

        return mapper.Map<SubscriptionViewModel>(subscription);
    }
}