using Domain.Common;

namespace Domain.Entities;

public class Genre : NamedEntity
{
    public virtual List<Book> Books { get; set; } = [];
}