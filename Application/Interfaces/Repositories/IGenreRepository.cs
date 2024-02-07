using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IGenreRepository : IBaseRepository<Genre>
{
    Task<bool> AddGenreToBookAsync(int genreId, int bookId, CancellationToken cancellationToken);
    Task<bool> DeleteGenreFromBookAsync(int genreId, int bookId, CancellationToken cancellationToken);
}