using Application.Extensions;
using FluentValidation;

namespace Application.Features.BookFeatures.Commands.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(b => b.ISBN.IsValidISBN()).Equal(true);
        RuleFor(b => b.Title).MaximumLength(100);
    }
}