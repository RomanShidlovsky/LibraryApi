using Application.DTOs.Author;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.AuthorFeatures.Queries.GetById;

public class GetAuthorByIdQueryHandler(
    IAuthorRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetAuthorByIdQuery, AuthorViewModel>
{
    public async Task<Response<AuthorViewModel>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await repository.GetByIdAsync(request.Id, cancellationToken);

        return author == null 
            ? Response.Failure<AuthorViewModel>(DomainErrors.Author.AuthorNotFoundById) 
            : mapper.Map<AuthorViewModel>(author);
    }
}