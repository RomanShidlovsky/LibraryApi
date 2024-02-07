namespace Application.DTOs.Author;

public sealed record DeleteAuthorFromBookDto(int BookId, int AuthorId);