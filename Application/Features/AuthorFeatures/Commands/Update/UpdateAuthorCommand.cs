using Application.DTOs.Author;
using Application.Interfaces.Commands;

namespace Application.Features.AuthorFeatures.Commands.Update;

public sealed record UpdateAuthorCommand : IUpdateCommand<AuthorViewModel>
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string FullName { get; init; }

    public UpdateAuthorCommand(UpdateAuthorDto dto)
    {
        Id = dto.Id;
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        FullName = dto.FullName;
    }
}