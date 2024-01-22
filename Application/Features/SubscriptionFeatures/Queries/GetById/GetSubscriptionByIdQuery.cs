using Application.DTOs.Subscription;
using Application.Interfaces.Queries;

namespace Application.Features.SubscriptionFeatures.Queries.GetById;

public record GetSubscriptionByIdQuery(int Id) : ISingleQuery<SubscriptionViewModel>;