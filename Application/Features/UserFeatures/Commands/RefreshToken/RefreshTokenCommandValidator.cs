using FluentValidation;

namespace Application.Features.UserFeatures.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(c => c.AccessToken)
            .NotEmpty().WithMessage("AccessToken is required.");
        RuleFor(c => c.RefreshToken)
            .NotEmpty().WithMessage("RefreshToken is required.");
    }
}