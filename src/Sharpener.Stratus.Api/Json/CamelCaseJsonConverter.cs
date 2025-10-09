// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Json;

/// <summary>
///     Custom JSON converter that applies camelCase naming policy to a specific class.
/// </summary>
/// <typeparam name="T">The type to convert</typeparam>
public class CamelCaseJsonConverter<T> : JsonConverter<T>
{
    private readonly JsonSerializerOptions _options;

    /// <summary>
    ///     Initializes a new <see cref="CamelCaseJsonConverter{T}" />.
    /// </summary>
    public CamelCaseJsonConverter()
    {
        _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, DefaultIgnoreCondition = JsonIgnoreCondition.Never
        };
    }

    /// <inheritdoc />
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<T>(ref reader, _options);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, _options);
    }
}
