using Domain.Common;

namespace Domain.Entities;

public class Role : NamedEntity
{
    public virtual List<User> Users { get; set; } = [];
}