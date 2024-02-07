namespace Application.DTOs.Book;

public record UpdateBookDto(
    int Id,
    string Title,
    string? Description);