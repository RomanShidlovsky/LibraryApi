using Application.DTOs.Role;
using Application.DTOs.Subscription;

namespace Application.DTOs.User;

public class UserViewModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public IList<string> Roles { get; set; } 
    public List<SubscriptionViewModel> Subscriptions { get; set; }
}