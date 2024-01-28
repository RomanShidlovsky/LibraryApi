using FluentValidation;

namespace Application.Features.UserFeatures.Commands.DeleteRole;

public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
{
    public DeleteUserRoleCommandValidator()
    {
        RuleFor(c => c.RoleName)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters.");
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}