using Application.DTOs.Subscription;
using Application.Interfaces.Commands;

namespace Application.Features.SubscriptionFeatures.Commands.Delete;

public sealed record DeleteSubscriptionCommand(int Id) : IDeleteCommand<SubscriptionViewModel>;