using Domain.Entities;

namespace Domain.Specifications.AuthorSpecifications;

public class ContainsBookSpecification(int bookId) :
    ExpressionSpecification<Author>(a => a.Books.Any(b => b.Id == bookId));
