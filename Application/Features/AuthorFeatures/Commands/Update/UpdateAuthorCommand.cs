using Application.DTOs.Author;
using Application.Interfaces.Commands;

namespace Application.Features.AuthorFeatures.Commands.Update;

public sealed record UpdateAuthorCommand(
    int Id,
    string FirstName,
    string LastName,
    string FullName) 
    : IUpdateCommand<AuthorViewModel>;