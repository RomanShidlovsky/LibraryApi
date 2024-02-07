using Application.DTOs.Subscription;
using Application.Interfaces.Commands;

namespace Application.Features.SubscriptionFeatures.Commands.Create;

public sealed record CreateSubscriptionCommand : ICreateCommand<SubscriptionViewModel>
{
    public int BookId { get; init; }
    public int UserId { get; init; }
    public DateTime ShouldReturnAt { get; init; }

    public CreateSubscriptionCommand(CreateSubscriptionDto dto)
    {
        BookId = dto.BookId;
        UserId = dto.UserId;
        ShouldReturnAt = dto.ShouldReturnAt;
    }
}