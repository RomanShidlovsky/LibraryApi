using Application.DTOs.Book;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.BookFeatures.Queries.GetById;

public class GetBookByIdQueryHandler(
    IBookRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetBookByIdQuery, BookViewModel>
{
    public async Task<Response<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.Id, cancellationToken);
        
        return book == null
            ? Response.Failure<BookViewModel>(DomainErrors.Book.BookNotFoundById) 
            : mapper.Map<BookViewModel>(book);
    }
}