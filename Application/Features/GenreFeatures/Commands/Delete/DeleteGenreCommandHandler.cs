using Application.DTOs.Genre;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.GenreFeatures.Commands.Delete;

public class DeleteGenreCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) 
    : IDeleteCommandHandler<DeleteGenreCommand, GenreViewModel>
{
    public async Task<Response<GenreViewModel>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IGenreRepository>();
        
        var genre = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (genre == null)
            return new NotFoundException(request.Id, typeof(Genre));
        
        repository.Delete(genre);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<GenreViewModel>(genre);
    }
}