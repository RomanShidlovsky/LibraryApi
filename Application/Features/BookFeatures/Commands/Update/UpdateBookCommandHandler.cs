using Application.DTOs.Book;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.BookFeatures.Commands.Update;

public class UpdateBookCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IUpdateCommandHandler<UpdateBookCommand, BookViewModel>
{
    public async Task<Response<BookViewModel>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IBookRepository>();
        var isbn = request.ISBN.Replace("-", "");

        var existingBook = await repository.GetByIsbnAsync(isbn, cancellationToken);
        if (existingBook != null)
            return new DuplicateException();

        var book = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (book == null)
            return new NotFoundException(request.Id, typeof(Book));
        
        book.ISBN = isbn;
        book.Title = request.Title;
        
        if (request.Description != null)
            book.Description = request.Description;

        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<BookViewModel>(book);
    }
}