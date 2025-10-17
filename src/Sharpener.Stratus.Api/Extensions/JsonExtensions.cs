// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Nodes;
using Sharpener.Json.Extensions;

namespace Sharpener.Stratus.Api.Extensions;

/// <summary>
///     Convenient extensions for JSON operations.
/// </summary>
public static class JsonExtensions
{
    /// <summary>
    ///     Using JSON serialization and deserialization, converts the free-form <see cref="JsonObject" /> reference into a
    ///     specific strongly typed object for better type safety. Note that if the JSON object had filtered properties, those
    ///     properties will be defaulted on the deserialization.
    /// </summary>
    /// <param name="jsonObject">The JSON object to convert to a defined static type.</param>
    /// <typeparam name="T">The type to convert to.</typeparam>
    /// <returns>A fully formed instance of the conversion type, or null if the process failed.</returns>
    public static T? As<T>(this JsonObject jsonObject)
    {
        var json = jsonObject.WriteJson();
        return json.ReadJsonAs<T>();
    }

    /// <summary>
    ///     Using JSON serialization and deserialization, converts the free-form <see cref="JsonObject" /> references into a
    ///     specific strongly typed object for better type safety. Note that if the JSON object had filtered properties, those
    ///     properties will be defaulted on the deserialization.
    /// </summary>
    /// <param name="jsonObjects">The JSON objects to convert to a defined static type.</param>
    /// <typeparam name="T">The type to convert to.</typeparam>
    /// <returns>A fully formed collection of the conversion type where conversion succeeded.</returns>
    public static IEnumerable<T>? As<T>(this IEnumerable<JsonObject> jsonObjects)
    {
        return jsonObjects.Select(jsonObject => jsonObject.As<T>()).OfType<T>().ToList();
    }
}
