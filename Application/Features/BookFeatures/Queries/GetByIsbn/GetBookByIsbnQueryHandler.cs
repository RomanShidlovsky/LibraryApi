using Application.DTOs.Book;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;

namespace Application.Features.BookFeatures.Queries.GetByISBN;

public class GetBookByIsbnQueryHandler(
    IBookRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetBookByIsbnQuery, BookViewModel>
{
    public async Task<Response<BookViewModel>> Handle(GetBookByIsbnQuery request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIsbnAsync(request.ISBN, cancellationToken);

        if (book == null)
            return new NotFoundException($"Book with ISBN: {request.ISBN} not found.");

        return mapper.Map<BookViewModel>(book);
    }
}