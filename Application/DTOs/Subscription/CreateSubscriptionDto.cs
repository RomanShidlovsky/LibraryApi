namespace Application.DTOs.Subscription;

public sealed record CreateSubscriptionDto(
    int BookId,
    int UserId,
    DateTime ShouldReturnAt);