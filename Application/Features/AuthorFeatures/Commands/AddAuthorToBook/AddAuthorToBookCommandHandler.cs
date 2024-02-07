﻿using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using Domain.Extensions;
using MediatR;

namespace Application.Features.AuthorFeatures.Commands.AddAuthorToBook;

public class AddAuthorToBookCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AddAuthorToBookCommand, Response>
{
    public async Task<Response> Handle(AddAuthorToBookCommand request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.GetRepository<IBookRepository>()
            .GetByIdAsync(request.BookId, cancellationToken);
        
        if (book == null)
            return Response.Failure(DomainErrors.Book.BookNotFoundById);
        
        if (book.ContainsAuthor(request.AuthorId))
            return Response.Failure(DomainErrors.Book.AlreadyContainsAuthor);

        var succeeded = await unitOfWork.GetRepository<IAuthorRepository>()
            .AddAuthorToBookAsync(request.AuthorId,request.BookId, cancellationToken);

        if (succeeded)
        {
            await unitOfWork.SaveAsync(cancellationToken);
        }

        return succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.Book.AuthorNotAdded);
    }
}