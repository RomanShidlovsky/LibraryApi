using Application.DTOs.Genre;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.GenreFeatures.Queries.GetById;

public class GetGenreByIdQueryHandler(
    IGenreRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetGenreByIdQuery, GenreViewModel>
{
    public async Task<Response<GenreViewModel>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre =  await repository.GetByIdAsync(request.Id, cancellationToken);

        if (genre is null)
            return new NotFoundException(request.Id, typeof(Genre));

        return mapper.Map<GenreViewModel>(genre);
    }
}