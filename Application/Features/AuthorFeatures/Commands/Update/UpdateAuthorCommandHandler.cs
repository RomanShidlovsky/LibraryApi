using Application.DTOs.Author;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;

namespace Application.Features.AuthorFeatures.Commands.Update;

public class UpdateAuthorCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IUpdateCommandHandler<UpdateAuthorCommand, AuthorViewModel>
{
    public async Task<Response<AuthorViewModel>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IAuthorRepository>();
        
        var author = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (author == null)
            return Response.Failure<AuthorViewModel>(DomainErrors.Author.AuthorNotFoundById);
        
        var updatedAuthor = mapper.Map<Author>(request);
        
        repository.Update(updatedAuthor);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<AuthorViewModel>(updatedAuthor);
    }
}