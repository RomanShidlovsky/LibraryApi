﻿using Application.DTOs.Author;
using Application.Wrappers;
using MediatR;

namespace Application.Features.AuthorFeatures.Commands.DeleteAuthorFromBook;

public sealed record DeleteAuthorFromBookCommand : IRequest<Response>
{
    public int BookId { get; init; }
    public int AuthorId { get; init; }

    public DeleteAuthorFromBookCommand(DeleteAuthorFromBookDto dto)
    {
        BookId = dto.BookId;
        AuthorId = dto.AuthorId;
    }
}
