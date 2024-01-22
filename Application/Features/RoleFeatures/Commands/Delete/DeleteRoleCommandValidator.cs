using FluentValidation;

namespace Application.Features.RoleFeatures.Commands.Delete;

public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(g => g.Id).NotEmpty();
    }
}