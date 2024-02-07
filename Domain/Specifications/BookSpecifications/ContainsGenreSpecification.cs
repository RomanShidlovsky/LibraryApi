using Domain.Entities;

namespace Domain.Specifications.BookSpecifications;

public class ContainsGenreSpecification(int genreId) :
    ExpressionSpecification<Book>(b => b.Genres.Any(g => g.Id == genreId)); 