using Application.Helpers;
using FluentValidation;

namespace Application.Features.BookFeatures.Commands.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(b => b.ISBN)
            .Must(IsbnHelper.IsValidIsbn).WithMessage("Invalid ISBN.");
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("The title field is required.")
            .MaximumLength(100).WithMessage("The title must not exceed 100 characters.");
    }
}