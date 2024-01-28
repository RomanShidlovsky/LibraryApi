using Domain.Common;

namespace Domain.Entities;

public class Genre : INamedEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Book> Books { get; set; } = [];
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateUpdated { get; set; }
}