using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class BookRepository(DataContext context) : BaseRepository<Book>(context), IBookRepository
{
    private IQueryable<Book> GetBookWithNavigationProperties()
    {
        return Context.Set<Book>()
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Include(b => b.Subscriptions);
    }

    public override Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return GetBookWithNavigationProperties()
            .SingleOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public override Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
    {
        return GetBookWithNavigationProperties()
            .ToListAsync(cancellationToken);
    }

    public Task<Book?> GetByIsbnAsync(string isbn, CancellationToken cancellationToken)
    {
        return GetBookWithNavigationProperties()
            .SingleOrDefaultAsync(b => b.ISBN == isbn, cancellationToken);
    }

    public async Task<bool> AddAuthorAsync(int bookId, int authorId, CancellationToken cancellationToken)
    {
        var book = await Context.Set<Book>()
            .Include(b => b.Authors)
            .SingleOrDefaultAsync(b => b.Id == bookId, cancellationToken: cancellationToken);

        if (book is null)
            return false;

        if (!book.Authors.Any(a => a.Id == authorId))
        {
            var author = await Context.Set<Author>()
                .FindAsync(authorId, cancellationToken);

            if (author is null)
                return false;

            if (Context.Entry(author).State == EntityState.Detached)
                Context.Attach(author);
            
            book.Authors.Add(author);
        }
        
        return true;
    }

    public Task<bool> DeleteAuthorAsync(int bookId, int authorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddGenreAsync(int bookId, int genreId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteGenreAsync(int bookId, int genreId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}