using Application.DTOs.Genre;
using Application.Wrappers;
using MediatR;

namespace Application.Features.GenreFeatures.Commands.DeleteGenreFromBook;

public sealed record DeleteGenreFromBookCommand : IRequest<Response>
{
    public int BookId { get; init; }
    public int GenreId { get; init; }

    public DeleteGenreFromBookCommand(DeleteGenreFromBookDto dto)
    {
        BookId = dto.BookId;
        GenreId = dto.GenreId;
    }
}