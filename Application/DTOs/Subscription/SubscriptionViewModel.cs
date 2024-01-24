namespace Application.DTOs.Subscription;

public sealed record SubscriptionViewModel(
    int Id,
    int BookId,
    int UserId,
    DateTime TakenAt,
    DateTime ShouldReturnAt,
    bool IsActive);