using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book?> GetByIsbnAsync(string isbn, CancellationToken cancellationToken);
}