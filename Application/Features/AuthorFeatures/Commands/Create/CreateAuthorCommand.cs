using Application.DTOs.Author;
using Application.Interfaces.Commands;

namespace Application.Features.AuthorFeatures.Commands.Create;

public sealed record CreateAuthorCommand(
    string FirstName,
    string LastName,
    string? FullName) 
    : ICreateCommand<AuthorViewModel>;