// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Json;

/// <summary>
///     Factory that creates camelCase converters for generic types.
/// </summary>
public class JsonCamelCaseClass : JsonConverterFactory
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        return true;
    }

    /// <inheritdoc />
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeof(JsonCamelCaseConverter<>).MakeGenericType(typeToConvert);
        return (JsonConverter?)Activator.CreateInstance(converterType);
    }
}
