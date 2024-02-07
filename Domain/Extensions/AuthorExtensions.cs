using Domain.Entities;
using Domain.Specifications.AuthorSpecifications;

namespace Domain.Extensions;

public static class AuthorExtensions
{
    public static bool ContainsBook(this Author author, int bookId)
    {
        var specification = new ContainsBookSpecification(bookId);
        return specification.IsSatisfied(author);
    }
}