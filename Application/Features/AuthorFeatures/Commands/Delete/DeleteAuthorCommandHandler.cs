using Application.DTOs.Author;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.AuthorFeatures.Commands.Delete;

public class DeleteAuthorCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IDeleteCommandHandler<DeleteAuthorCommand, AuthorViewModel>
{
    public async Task<Response<AuthorViewModel>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IAuthorRepository>();

        var author = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (author == null)
            return new NotFoundException(request.Id, typeof(Author));
        
        repository.Delete(author);

        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<AuthorViewModel>(author);
    }
}