// The Sharpener project licenses this file to you under the MIT license.

namespace Sharpener.Stratus.Api.Extensions;

public static class StringExtensions
{
    /// <summary>
    ///     Sets the first character in a string to lower case.
    /// </summary>
    /// <remarks>
    ///     Useful for, but not limited to, camel case conversions of strings.
    /// </remarks>
    /// <param name="value">The value whose first character should be lowercase.</param>
    /// <returns>A string with a lowercase first letter if it's alphabetic.</returns>
    public static string ToLowerStart(this string value)
    {
        if (string.IsNullOrEmpty(value) || char.IsLower(value[0]))
        {
            return value;
        }

        if (value.Length == 1)
        {
            return char.ToLowerInvariant(value[0]).ToString();
        }

        // ReSharper disable once ReplaceSubstringWithRangeIndexer
        return char.ToLowerInvariant(value[0]) + value.Substring(1);
    }
}
