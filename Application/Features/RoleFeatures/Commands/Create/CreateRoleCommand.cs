using Application.DTOs.Role;
using Application.Interfaces.Commands;

namespace Application.Features.RoleFeatures.Commands.Create;

public sealed record CreateRoleCommand : ICreateCommand<RoleViewModel>
{
    public string Name { get; init; }

    public CreateRoleCommand(CreateRoleDto dto)
    {
        Name = dto.Name;
    }
}