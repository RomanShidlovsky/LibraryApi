using Application.DTOs.Genre;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;

namespace Application.Features.GenreFeatures.Commands.Create;

public class CreateGenreCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) 
    : ICreateCommandHandler<CreateGenreCommand, GenreViewModel>
{
    public async Task<Response<GenreViewModel>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IGenreRepository>();
        
        var genre = (await repository.GetAsync(g => g.Name == request.Name, cancellationToken)).SingleOrDefault();

        if (genre != null)
            return Response.Failure<GenreViewModel>(DomainErrors.Genre.NameConflict);

        var newGenre = mapper.Map<Genre>(request);
        repository.Create(newGenre);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<GenreViewModel>(newGenre);
    }
}