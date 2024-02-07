using Domain.Entities;

namespace Domain.Specifications.BookSpecifications;

public class CanReturnSpecification()
    : ExpressionSpecification<Book>(b => b.Subscriptions.LastOrDefault() != null && b.Subscriptions.Last().IsActive);