using System.Text.RegularExpressions;

namespace Application.Helpers;

public static partial class IsbnHelper
{
    private const string ISBNPattern = @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$";
    
    [GeneratedRegex(ISBNPattern)]
    private static partial Regex IsbnRegex();
    
    
    public static bool IsValidIsbn(string isbn)
    {
        return IsbnRegex().IsMatch(isbn);
    }
}