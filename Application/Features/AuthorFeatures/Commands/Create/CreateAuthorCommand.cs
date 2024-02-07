using Application.DTOs.Author;
using Application.Interfaces.Commands;

namespace Application.Features.AuthorFeatures.Commands.Create;

public sealed record CreateAuthorCommand : ICreateCommand<AuthorViewModel>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string? FullName { get; init; }
    
    public CreateAuthorCommand(CreateAuthorDto dto)
    {
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        FullName = dto.FullName;
    }
}