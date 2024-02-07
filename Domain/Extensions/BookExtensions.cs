using Domain.Entities;
using Domain.Specifications.BookSpecifications;

namespace Domain.Extensions;

public static class BookExtensions
{
    public static bool CanReturn(this Book book)
    {
        var specification = new CanReturnSpecification();
        return specification.IsSatisfied(book);
    }

    public static bool ContainsAuthor(this Book book, int authorId)
    {
        var specification = new ContainsAuthorSpecification(authorId);
        return specification.IsSatisfied(book);
    }
}