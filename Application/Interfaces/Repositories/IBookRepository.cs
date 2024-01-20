using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book?> GetByIsbn(string isbn, CancellationToken cancellationToken);
    bool AddAuthor(int bookId, int authorId);
    bool DeleteAuthor(int bookId, int authorId);
    bool AddGenre(int bookId, int genreId);
    bool DeleteGenre(int bookId, int genreId);
}