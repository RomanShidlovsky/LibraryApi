using Application.DTOs.Subscription;
using Application.Interfaces.Commands;

namespace Application.Features.SubscriptionFeatures.Commands.Create;

public sealed record CreateSubscriptionCommand(
    int BookId,
    int UserId,
    DateTime ShouldReturnAt)
    : ICreateCommand<SubscriptionViewModel>;