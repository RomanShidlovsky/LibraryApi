using Application.DTOs.Genre;
using Application.Wrappers;
using MediatR;

namespace Application.Features.GenreFeatures.Commands.AddGenreToBook;

public sealed record AddGenreToBookCommand : IRequest<Response>
{
    public int BookId { get; init; }
    public int GenreId { get; init; }

    public AddGenreToBookCommand(AddGenreToBookDto dto)
    {
        BookId = dto.BookId;
        GenreId = dto.GenreId;
    }
}