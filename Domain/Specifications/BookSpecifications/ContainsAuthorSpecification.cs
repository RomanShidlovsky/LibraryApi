using Domain.Entities;

namespace Domain.Specifications.BookSpecifications;

public class ContainsAuthorSpecification(int authorId)
    : ExpressionSpecification<Book>(b => b.Authors.Any(a => a.Id == authorId));
