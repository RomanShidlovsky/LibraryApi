using Application.Extensions;
using FluentValidation;

namespace Application.Features.BookFeatures.Queries.GetByISBN;

public class GetBookByIsbnQueryValidator : AbstractValidator<GetBookByIsbnQuery>
{
    public GetBookByIsbnQueryValidator()
    {
        RuleFor(b => b.ISBN.IsValidISBN())
            .Equal(true)
            .WithMessage("Invalid ISBN");
    }
}