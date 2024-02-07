using Application.DTOs.Author;
using Application.Wrappers;
using MediatR;

namespace Application.Features.AuthorFeatures.Commands.AddAuthorToBook;

public sealed record AddAuthorToBookCommand : IRequest<Response>
{
    public int BookId { get; init; }
    public int AuthorId { get; init; }

    public AddAuthorToBookCommand(AddAuthorToBookDto dto)
    {
        BookId = dto.BookId;
        AuthorId = dto.AuthorId;
    }
}