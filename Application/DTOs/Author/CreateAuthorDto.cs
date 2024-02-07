namespace Application.DTOs.Author;

public sealed record CreateAuthorDto(
    string FirstName,
    string LastName,
    string? FullName);