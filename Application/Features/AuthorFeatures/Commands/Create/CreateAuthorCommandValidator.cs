using FluentValidation;

namespace Application.Features.AuthorFeatures.Commands.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(a => a.FirstName)
            .NotEmpty()
            .MaximumLength(25);
        RuleFor(a => a.LastName)
            .NotEmpty()
            .MaximumLength(25);
        RuleFor(a => a.FullName)
            .MaximumLength(100);
    }
}