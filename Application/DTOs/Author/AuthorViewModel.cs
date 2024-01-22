namespace Application.DTOs.Author;

public sealed record AuthorViewModel(
    string FirstName,
    string LastName,
    string FullName);