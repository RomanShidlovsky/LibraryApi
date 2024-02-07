namespace Application.DTOs.Genre;

public sealed record AddGenreToBookDto(int BookId, int GenreId);