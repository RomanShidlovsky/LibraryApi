using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class AuthorRepository(DataContext context) : BaseRepository<Author>(context), IAuthorRepository
{
    public async Task<bool> AddAuthorToBookAsync(int authorId, int bookId, CancellationToken cancellationToken)
    {
        var book = await Context.Set<Book>()
            .FirstOrDefaultAsync(b => b.Id == bookId, cancellationToken);

        if (book == null)
            return false;
        
        var author = await GetEntitySet()
            .FirstOrDefaultAsync(a => a.Id == authorId, cancellationToken);
        
        if (author == null)
            return false;
        
        book.Authors.Add(author);
        return true;
    }

    public async Task<bool> DeleteAuthorFromBookAsync(int authorId, int bookId, CancellationToken cancellationToken)
    {
        var book = await Context.Set<Book>()
            .FirstOrDefaultAsync(b => b.Id == bookId, cancellationToken);

        if (book == null)
            return false;

        var author = await GetEntitySet()
            .FirstOrDefaultAsync(a => a.Id == authorId, cancellationToken);

        if (author == null)
            return false;

        return book.Authors.Remove(author);
    }
}