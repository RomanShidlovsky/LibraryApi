using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAuthorRepository : IBaseRepository<Author>
{
    Task<bool> AddAuthorToBookAsync(int authorId, int bookId,  CancellationToken cancellationToken);
    Task<bool> DeleteAuthorFromBookAsync(int authorId, int bookId, CancellationToken cancellationToken);
}