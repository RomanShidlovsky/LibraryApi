using Application.DTOs.Genre;
using Application.Exceptions;
using Application.Features.GenreFeatures.Commands.Delete;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.GenreFeatures.Commands.Update;

public class UpdateGenreCommandHandler(
    IUnitOfWork unitOfWork, 
    IMapper mapper) 
    : IUpdateCommandHandler<UpdateGenreCommand, GenreViewModel>
{
    public async Task<Response<GenreViewModel>> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IGenreRepository>();
        
        var genre = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (genre == null)
            return new NotFoundException(request.Id, typeof(Genre));

        var updatedGenre = mapper.Map<Genre>(request);
        
        repository.Update(updatedGenre);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<GenreViewModel>(updatedGenre);
    }
}