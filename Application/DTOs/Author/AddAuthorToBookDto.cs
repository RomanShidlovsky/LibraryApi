namespace Application.DTOs.Author;

public sealed record AddAuthorToBookDto(int BookId, int AuthorId);