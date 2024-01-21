using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book?> GetByIsbnAsync(string isbn, CancellationToken cancellationToken);
    Task<bool> AddAuthorAsync(int bookId, int authorId, CancellationToken cancellationToken);
    Task<bool> DeleteAuthorAsync(int bookId, int authorId, CancellationToken cancellationToken);
    Task<bool> AddGenreAsync(int bookId, int genreId, CancellationToken cancellationToken);
    Task<bool> DeleteGenreAsync(int bookId, int genreId, CancellationToken cancellationToken);
}