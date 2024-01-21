using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class BaseRepository<T>
    : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataContext Context;

    public BaseRepository(DataContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
        Context.Add(entity);
    }

    public void Update(T entity)
    {
        entity.DateUpdated = DateTimeOffset.Now;
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        Context.Remove(entity);
    }

    public virtual Task<List<T>> Get(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
    {
        return Context.Set<T>().Where(expression).ToListAsync(cancellationToken);
    }

    public virtual Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public virtual Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Context.Set<T>().ToListAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().AnyAsync(t => t.Id == id, cancellationToken);
    }
}