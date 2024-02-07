using Application.DTOs.Book;
using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.Create;

public sealed record CreateBookCommand : ICreateCommand<BookViewModel>
{
    public string ISBN { get; init; }
    public string Title { get; init; }
    public string? Description { get; init; }
    public IEnumerable<int> AuthorIds { get; init; }
    public IEnumerable<int> GenreIds { get; init; }

    public CreateBookCommand(CreateBookDto dto)
    {
        ISBN = dto.ISBN;
        Title = dto.Title;
        Description = dto.Description;
        AuthorIds = dto.AuthorIds;
        GenreIds = dto.GenreIds;
    }
}