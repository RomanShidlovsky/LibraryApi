using FluentValidation;

namespace Application.Features.UserFeatures.Commands.AddRole;

public class AddUserRoleCommandValidator : AbstractValidator<AddUserRoleCommand>
{
    public AddUserRoleCommandValidator()
    {
        RuleFor(c => c.RoleId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}