using FluentValidation;

namespace Application.Features.UserFeatures.Commands.DeleteRole;

public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
{
    public DeleteUserRoleCommandValidator()
    {
        RuleFor(c => c.RoleId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}