using System.Text.RegularExpressions;

namespace Application.Extensions;

public static partial class StringExtensions
{
    [GeneratedRegex("^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\\\\d-]+$")]
    private static partial Regex Regex();

    public static bool IsValidISBN(this string isbn)
    {
        return Regex().IsMatch(isbn);
    }

    
}