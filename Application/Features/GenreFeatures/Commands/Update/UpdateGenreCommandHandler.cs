using Application.DTOs.Genre;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;

namespace Application.Features.GenreFeatures.Commands.Update;

public class UpdateGenreCommandHandler(
    IUnitOfWork unitOfWork, 
    IMapper mapper) 
    : IUpdateCommandHandler<UpdateGenreCommand, GenreViewModel>
{
    public async Task<Response<GenreViewModel>> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IGenreRepository>();
        
        var existingGenre = (await repository.GetAsync(g => g.Name == request.Name, cancellationToken)).SingleOrDefault();

        if (existingGenre != null)
            return Response.Failure<GenreViewModel>(DomainErrors.Genre.NameConflict);
        
        var genre = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (genre == null)
            return Response.Failure<GenreViewModel>(DomainErrors.Genre.GenreNotFoundById);

        var updatedGenre = mapper.Map<Genre>(request);
        
        repository.Update(updatedGenre);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<GenreViewModel>(updatedGenre);
    }
}