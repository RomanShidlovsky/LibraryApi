using Application.DTOs.Genre;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.GenreFeatures.Queries.GetById;

public class GetGenreByIdQueryHandler(
    IGenreRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetGenreByIdQuery, GenreViewModel>
{
    public async Task<Response<GenreViewModel>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await repository.GetByIdAsync(request.Id, cancellationToken);

        return genre == null
            ? Response.Failure<GenreViewModel>(DomainErrors.Genre.GenreNotFoundById)
            : mapper.Map<GenreViewModel>(genre); 
    }
}