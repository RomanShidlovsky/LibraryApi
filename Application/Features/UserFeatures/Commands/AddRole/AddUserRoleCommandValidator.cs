using FluentValidation;

namespace Application.Features.UserFeatures.Commands.AddRole;

public class AddUserRoleCommandValidator : AbstractValidator<AddUserRoleCommand>
{
    public AddUserRoleCommandValidator()
    {
        RuleFor(c => c.RoleId)
            .NotEmpty().WithMessage("RoleId is required.");
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}