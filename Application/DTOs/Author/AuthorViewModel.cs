namespace Application.DTOs.Author;

public sealed record AuthorViewModel(
    int Id,
    string FirstName,
    string LastName,
    string FullName);