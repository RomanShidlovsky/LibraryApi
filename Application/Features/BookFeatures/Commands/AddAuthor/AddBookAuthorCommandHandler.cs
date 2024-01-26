using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using MediatR;

namespace Application.Features.BookFeatures.Commands.AddAuthor;

public class AddBookAuthorCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AddBookAuthorCommand, Response>
{
    public async Task<Response> Handle(AddBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var succeeded = await unitOfWork.GetRepository<IBookRepository>()
            .AddAuthorAsync(request.BookId, request.AuthorId, cancellationToken);

        if (succeeded)
        {
            await unitOfWork.SaveAsync(cancellationToken);
        }

        return succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.Book.AuthorNotAdded);
    }
}