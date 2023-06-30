using System.Text.RegularExpressions;

namespace SmartGenealogy.Core.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Check whether a string is a valid e-mail address.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>True if valid; otherwise false.</returns>
    public static bool IsValidEmailAddress(this string input)
    {
        var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        return regex.IsMatch(input);
    }

    /// <summary>
    /// Strip HTML from the input string.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>String with no HTML.</returns>
    public static string StripHtml(this string input)
    {
        // Will this simple expression replace all tags???
        var regex = new Regex(@"</?.+?>");
        return regex.Replace(input, " ");
    }
}