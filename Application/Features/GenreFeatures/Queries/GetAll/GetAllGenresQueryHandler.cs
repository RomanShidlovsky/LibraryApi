using Application.DTOs.Genre;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;

namespace Application.Features.GenreFeatures.Queries.GetAll;

public class GetAllGenresQueryHandler(
    IGenreRepository repository,
    IMapper mapper)
    : IQueryHandler<GetAllGenresQuery, IEnumerable<GenreViewModel>>
{
    public async Task<Response<IEnumerable<GenreViewModel>>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genresList = await repository.GetAllAsync(cancellationToken);

        return new Response<IEnumerable<GenreViewModel>>(mapper.Map<IEnumerable<GenreViewModel>>(genresList));
    }
}