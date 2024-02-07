namespace Application.DTOs.Book;

public sealed record CreateBookDto(
    string ISBN,
    string Title,
    string? Description,
    IEnumerable<int> AuthorIds,
    IEnumerable<int> GenreIds);