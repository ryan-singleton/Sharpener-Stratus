// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     The definition for malleably shaped response types for the Stratus API.
/// </summary>
public interface IJsonResponse
{
    /// <summary>
    ///     The internally stored JSON data for serialization and deserialization. This gets automatically used instead
    ///     of the class itself.
    /// </summary>
    Dictionary<string, JsonElement> Data { get; set; }
}
