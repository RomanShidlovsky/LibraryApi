using Application.Features.BookFeatures.Commands.Delete;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using MediatR;

namespace Application.Features.BookFeatures.Commands.DeleteAuthor;

public class DeleteBookAuthorCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBookAuthorCommand, Response>
{
    public async Task<Response> Handle(DeleteBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var succeeded = await unitOfWork.GetRepository<IBookRepository>()
            .DeleteAuthorAsync(request.BookId, request.AuthorId, cancellationToken);

        if (succeeded)
        {
            await unitOfWork.SaveAsync(cancellationToken);
        }
        
        return succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.Book.AuthorNotDeleted);
    }
}