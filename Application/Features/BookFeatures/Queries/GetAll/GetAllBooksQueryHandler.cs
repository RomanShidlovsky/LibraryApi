using Application.DTOs.Book;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;

namespace Application.Features.BookFeatures.Queries.GetAll;

public class GetAllBooksQueryHandler(
    IBookRepository repository,
    IMapper mapper)
    : IQueryHandler<GetAllBooksQuery, IEnumerable<BookViewModel>>
{
    public async Task<Response<IEnumerable<BookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var booksList = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<List<BookViewModel>>(booksList);
    }
}