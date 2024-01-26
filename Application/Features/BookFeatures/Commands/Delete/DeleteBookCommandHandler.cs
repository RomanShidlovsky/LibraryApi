using Application.DTOs.Book;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.BookFeatures.Commands.Delete;

public class DeleteBookCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IDeleteCommandHandler<DeleteBookCommand, BookViewModel>
{
    public async Task<Response<BookViewModel>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IBookRepository>();

        var book = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (book == null)
            return Response.Failure<BookViewModel>(DomainErrors.Book.BookNotFoundById);
        
        repository.Delete(book);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<BookViewModel>(book);
    }
}