using FluentValidation;

namespace Application.Features.UserFeatures.Commands.DeleteRole;

public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
{
    public DeleteUserRoleCommandValidator()
    {
        RuleFor(c => c.RoleId)
            .NotEmpty().WithMessage("RoleId is required.");
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}