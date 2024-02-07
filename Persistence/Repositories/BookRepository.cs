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
            .FirstOrDefaultAsync(b => b.ISBN == isbn, cancellationToken);
    }
}