using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class BookRepository(DataContext context) : BaseRepository<Book>(context), IBookRepository
{
    protected override IQueryable<Book> GetEntitySet()
    {
        return Context.Set<Book>()
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Include(b => b.Subscriptions);
    }

    public Task<Book?> GetByIsbnAsync(string isbn, CancellationToken cancellationToken)
    {
        return GetEntitySet()
            .SingleOrDefaultAsync(b => b.ISBN == isbn, cancellationToken);
    }
    
    public async Task<bool> AddGenreAsync(int bookId, int genreId, CancellationToken cancellationToken)
    {
        var book = await Context.Set<Book>()
            .Include(b => b.Genres)
            .SingleOrDefaultAsync(b => b.Id == bookId, cancellationToken);

        if (book == null)
            return false;

        if (!book.Genres.Any(g => g.Id == genreId))
        {
            var genre = await Context.Set<Genre>()
                .FindAsync(genreId, cancellationToken);

            if (genre == null)
                return false;
            
            book.Genres.Add(genre);
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteGenreAsync(int bookId, int genreId, CancellationToken cancellationToken)
    {
        var book = await Context.Set<Book>()
            .Include(b => b.Genres)
            .SingleOrDefaultAsync(b => b.Id == bookId, cancellationToken);

        if (book == null)
            return false;

        var genre = book.Genres.SingleOrDefault(g => g.Id == genreId);

        if (genre == null)
            return false;

        return book.Genres.Remove(genre);
    }
}