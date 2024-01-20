using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class BookRepository(DataContext context) : BaseRepository<Book>(context), IBookRepository
{
    public Task<Book?> GetByIsbn(string isbn, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public bool AddAuthor(int bookId, int authorId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteAuthor(int bookId, int authorId)
    {
        throw new NotImplementedException();
    }

    public bool AddGenre(int bookId, int genreId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteGenre(int bookId, int genreId)
    {
        throw new NotImplementedException();
    }
}