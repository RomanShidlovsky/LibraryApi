using Application.DTOs.Author;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;

namespace Application.Features.AuthorFeatures.Queries.GetAll;

public class GetAllAuthorsQueryHandler(
    IAuthorRepository repository,
    IMapper mapper)
    : IQueryHandler<GetAllAuthorsQuery, IEnumerable<AuthorViewModel>>
{
    public async Task<Response<IEnumerable<AuthorViewModel>>> Handle(GetAllAuthorsQuery request,
        CancellationToken cancellationToken)
    {
        var authorsList = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<List<AuthorViewModel>>(authorsList);
    }
}