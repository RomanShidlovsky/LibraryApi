using Application.DTOs.Author;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.AuthorFeatures.Queries.GetById;

public class GetAuthorByIdQueryHandler(
    IAuthorRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetAuthorByIdQuery, AuthorViewModel>
{
    public async Task<Response<AuthorViewModel>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (author == null)
            return new NotFoundException(request.Id, typeof(Author));

        return mapper.Map<AuthorViewModel>(author);
    }
}