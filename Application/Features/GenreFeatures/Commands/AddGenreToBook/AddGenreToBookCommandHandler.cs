using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using Domain.Extensions;
using MediatR;

namespace Application.Features.GenreFeatures.Commands.AddGenreToBook;

public class AddGenreToBookCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AddGenreToBookCommand, Response>
{
    public async Task<Response> Handle(AddGenreToBookCommand request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.GetRepository<IBookRepository>()
            .GetByIdAsync(request.BookId, cancellationToken);
        
        if (book == null)
            return Response.Failure(DomainErrors.Book.BookNotFoundById);
        
        if (book.ContainsGenre(request.GenreId))
            return Response.Failure(DomainErrors.Book.AlreadyContainsGenre);

        var succeeded = await unitOfWork.GetRepository<IGenreRepository>()
            .AddGenreToBookAsync(request.GenreId,request.BookId, cancellationToken);

        if (succeeded)
        {
            await unitOfWork.SaveAsync(cancellationToken);
        }

        return succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.Book.GenreNotAdded);
    }
}