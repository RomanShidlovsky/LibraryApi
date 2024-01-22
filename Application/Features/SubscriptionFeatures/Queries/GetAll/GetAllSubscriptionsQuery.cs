using Application.DTOs.Subscription;
using Application.Interfaces.Queries;

namespace Application.Features.SubscriptionFeatures.Queries.GetAll;

public sealed record GetAllSubscriptionsQuery() : IQuery<IEnumerable<SubscriptionViewModel>>;