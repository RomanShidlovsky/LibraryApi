using Application.DTOs.Book;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.BookFeatures.Queries.GetByISBN;

public class GetBookByIsbnQueryHandler(
    IBookRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetBookByIsbnQuery, BookViewModel>
{
    public async Task<Response<BookViewModel>> Handle(GetBookByIsbnQuery request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIsbnAsync(request.ISBN, cancellationToken);

        return book == null
            ? Response.Failure<BookViewModel>(DomainErrors.Book.BookNotFoundByIsbn) 
            : mapper.Map<BookViewModel>(book);
    }
}