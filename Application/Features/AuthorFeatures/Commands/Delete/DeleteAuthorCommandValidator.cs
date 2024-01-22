using FluentValidation;

namespace Application.Features.AuthorFeatures.Commands.Delete;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty();
    }
}