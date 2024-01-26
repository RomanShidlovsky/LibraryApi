using System.Text.RegularExpressions;

namespace Application.Helpers;

public static partial class IsbnHelper
{
    [GeneratedRegex("^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\\\\d-]+$")]
    private static partial Regex Regex();

    public static bool IsValidIsbn(string isbn)
    {
        return Regex().IsMatch(isbn);
    }
}