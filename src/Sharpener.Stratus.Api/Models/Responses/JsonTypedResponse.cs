// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     A response type that is malleable but also associated to a more strongly typed end result of <see cref="T" />.
/// </summary>
/// <typeparam name="T">The strong type associated with this malleable type.</typeparam>
public abstract class JsonTypedResponse<T> : IJsonResponse where T : class
{
    /// <inheritdoc />
    [JsonExtensionData]
    public Dictionary<string, JsonElement> Data { get; set; } = [];

    /// <summary>
    ///     Casts the flexibly typed object to an actual <see cref="T" />. Note, however, that any properties that
    ///     were not obtained from the web request will be unreliable.
    /// </summary>
    /// <returns>A strongly typed <see cref="T" />.</returns>
    public T? Stratify()
    {
        var json = JsonSerializer.Serialize(Data);
        return JsonSerializer.Deserialize<T>(json);
    }
}
