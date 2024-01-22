using Domain.Common;

namespace Domain.Entities;

public class Book : BaseEntity
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public virtual List<Author> Authors { get; set; }
    public virtual List<Genre> Genres { get; set; }
    public virtual List<Subscription> Subscriptions { get; set; } = [];
}