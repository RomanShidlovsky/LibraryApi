using Application.DTOs.Book;
using Application.Exceptions;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

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
            return new NotFoundException(request.Id, typeof(Book));
        
        repository.Delete(book);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<BookViewModel>(book);
    }
}