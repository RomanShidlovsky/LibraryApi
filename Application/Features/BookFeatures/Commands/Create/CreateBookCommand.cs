using Application.DTOs.Book;
using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.Create;

public sealed record CreateBookCommand(
    string ISBN,
    string Title,
    string? Description,
    IEnumerable<int> AuthorIds,
    IEnumerable<int> GenreIds)
    : ICreateCommand<BookViewModel>;