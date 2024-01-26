using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using MediatR;

namespace Application.Features.BookFeatures.Commands.AddGenre;

public class AddBookGenreCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AddBookGenreCommand, Response>
{
    public async Task<Response> Handle(AddBookGenreCommand request, CancellationToken cancellationToken)
    {
        var succeeded = await unitOfWork.GetRepository<IBookRepository>()
            .AddGenreAsync(request.BookId, request.GenreId, cancellationToken);

        if (succeeded)
        {
            await unitOfWork.SaveAsync(cancellationToken);
        }

        return succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.Book.GenreNotAdded);
    }
}