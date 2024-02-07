namespace Application.DTOs.Author;

public sealed record UpdateAuthorDto(
    int Id,
    string FirstName,
    string LastName,
    string FullName);