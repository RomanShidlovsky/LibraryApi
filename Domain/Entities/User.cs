using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public virtual List<Subscription> Subscriptions { get; set; } = [];
    public virtual List<Role> Roles { get; set; } = [];
}