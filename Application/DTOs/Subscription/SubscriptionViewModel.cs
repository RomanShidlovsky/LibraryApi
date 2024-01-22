namespace Application.DTOs.Subscription;

public sealed record SubscriptionViewModel(
    int BookId,
    int UserId,
    DateTime TakenAt,
    DateTime ShouldReturnAt,
    bool IsActive);