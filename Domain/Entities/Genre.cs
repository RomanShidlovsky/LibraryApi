using Domain.Common;

namespace Domain.Entities;

public class Genre : NamedEntity
{
    public List<Book> Books { get; set; } = [];
}