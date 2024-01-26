using Application.DTOs.Author;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

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
            return Response.Failure<AuthorViewModel>(DomainErrors.Author.AuthorNotFoundById);
        
        repository.Delete(author);

        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<AuthorViewModel>(author);
    }
}