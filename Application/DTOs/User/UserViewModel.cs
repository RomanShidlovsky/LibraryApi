using Application.DTOs.Role;
using Application.DTOs.Subscription;

namespace Application.DTOs.User;

public sealed record UserViewModel(
    int Id,
    string Email,
    string Username,
    List<SubscriptionViewModel> Subscriptions,
    List<RoleViewModel> Roles);