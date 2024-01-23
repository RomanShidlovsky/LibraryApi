using Application.DTOs.Book;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.BookFeatures.Queries.GetById;

public class GetBookByIdQueryHandler(
    IBookRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetBookByIdQuery, BookViewModel>
{
    public async Task<Response<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (book == null)
            return new NotFoundException(request.Id, typeof(Book));

        return mapper.Map<BookViewModel>(book);
    }
}