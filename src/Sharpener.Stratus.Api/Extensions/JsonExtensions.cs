// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Json.Extensions;
using Sharpener.Stratus.Api.Models.Responses;

namespace Sharpener.Stratus.Api.Extensions;

/// <summary>
///     Convenient extensions for JSON operations.
/// </summary>
public static class JsonExtensions
{
    /// <summary>
    ///     Using JSON serialization and deserialization, converts the free-form <see cref="IJsonResponse" /> reference into a
    ///     specific strongly typed object for better type safety. Note that if the JSON object had filtered properties, those
    ///     properties will be defaulted on the deserialization.
    /// </summary>
    /// <param name="jsonResponse">The JSON object to convert to a defined static type.</param>
    /// <typeparam name="T">The type to convert to.</typeparam>
    /// <returns>A fully formed instance of the conversion type, or null if the process failed.</returns>
    internal static T? As<T>(this IJsonResponse jsonResponse)
    {
        var json = jsonResponse.WriteJson();
        return json.ReadJsonAs<T>();
    }
}
