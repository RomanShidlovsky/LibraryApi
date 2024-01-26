using Application.Helpers;
using FluentValidation;

namespace Application.Features.BookFeatures.Queries.GetByISBN;

public class GetBookByIsbnQueryValidator : AbstractValidator<GetBookByIsbnQuery>
{
    public GetBookByIsbnQueryValidator()
    {
        RuleFor(b => b.ISBN)
            .Must(IsbnHelper.IsValidIsbn).WithMessage("Invalid ISBN.");
    }
}