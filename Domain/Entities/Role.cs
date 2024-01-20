using Domain.Common;

namespace Domain.Entities;

public class Role : NamedEntity
{
    public List<User> Users { get; set; } = [];
}