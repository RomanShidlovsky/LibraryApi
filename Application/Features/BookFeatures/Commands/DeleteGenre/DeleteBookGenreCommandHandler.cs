using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using MediatR;

namespace Application.Features.BookFeatures.Commands.DeleteGenre;

public class DeleteBookGenreCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBookGenreCommand, Response>
{
    public async Task<Response> Handle(DeleteBookGenreCommand request, CancellationToken cancellationToken)
    {
        var succeeded = await unitOfWork.GetRepository<IBookRepository>()
            .DeleteGenreAsync(request.BookId, request.GenreId, cancellationToken);

        if (succeeded)
        {
            await unitOfWork.SaveAsync(cancellationToken);
        }

        return succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.Book.GenreNotDeleted);
    }
}