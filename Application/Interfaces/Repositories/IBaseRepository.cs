using System.Linq.Expressions;
using Domain.Common;

namespace Application.Interfaces.Repositories;

public interface IBaseRepository;

public interface IBaseRepository<T> : IBaseRepository
    where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<List<T>> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
}