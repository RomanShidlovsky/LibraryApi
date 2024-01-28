using Domain.Common;

namespace Domain.Entities;

public class Book : IBaseEntity
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public virtual List<Author> Authors { get; set; } = [];
    public virtual List<Genre> Genres { get; set; } = [];
    public virtual List<Subscription> Subscriptions { get; set; } = [];
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateUpdated { get; set; }
}