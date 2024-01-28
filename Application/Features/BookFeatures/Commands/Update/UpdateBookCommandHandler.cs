using Application.DTOs.Book;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.BookFeatures.Commands.Update;

public class UpdateBookCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IUpdateCommandHandler<UpdateBookCommand, BookViewModel>
{
    public async Task<Response<BookViewModel>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IBookRepository>();
        
        var book = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (book == null)
            return Response.Failure<BookViewModel>(DomainErrors.Book.BookNotFoundById);
        
        book.Title = request.Title;
        
        if (request.Description != null)
            book.Description = request.Description;

        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<BookViewModel>(book);
    }
}