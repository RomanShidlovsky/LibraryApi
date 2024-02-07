using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class GenreRepository(DataContext context) : BaseRepository<Genre>(context), IGenreRepository
{
    public async Task<bool> AddGenreToBookAsync(int genreId, int bookId, CancellationToken cancellationToken)
    {
        var book = await Context.Set<Book>()
            .FirstOrDefaultAsync(b => b.Id == bookId, cancellationToken);

        if (book == null)
            return false;
        
        var genre = await GetEntitySet()
            .FirstOrDefaultAsync(a => a.Id == genreId, cancellationToken);
        
        if (genre == null)
            return false;
        
        book.Genres.Add(genre);
        return true;
    }

    public async Task<bool> DeleteGenreFromBookAsync(int genreId, int bookId, CancellationToken cancellationToken)
    {
        var book = await Context.Set<Book>()
            .FirstOrDefaultAsync(b => b.Id == bookId, cancellationToken);

        if (book == null)
            return false;

        var genre = await GetEntitySet()
            .FirstOrDefaultAsync(a => a.Id == genreId, cancellationToken);

        if (genre == null)
            return false;

        return book.Genres.Remove(genre);
    }
}