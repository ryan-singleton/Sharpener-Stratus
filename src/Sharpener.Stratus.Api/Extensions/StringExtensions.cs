// The Sharpener project licenses this file to you under the MIT license.

namespace Sharpener.Stratus.Api.Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        return char.ToLowerInvariant(value[0]) + value.Substring(1);
    }
}
