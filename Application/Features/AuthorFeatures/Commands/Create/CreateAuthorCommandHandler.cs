using Application.DTOs.Author;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.AuthorFeatures.Commands.Create;

public class CreateAuthorCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) 
    : ICreateCommandHandler<CreateAuthorCommand, AuthorViewModel>
{
    public async Task<Response<AuthorViewModel>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = mapper.Map<Author>(request);
        if (request.FullName == null)
        {
            author.FullName = $"{author.FirstName} {author.LastName}";
        }
        
        unitOfWork.GetRepository<IAuthorRepository>().Create(author);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<AuthorViewModel>(author);
    }
}