// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Json;

/// <summary>
///     Factory that creates camelCase converters for generic types.
/// </summary>
public class CamelCaseConverterFactory : JsonConverterFactory
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        // This factory handles the specific types you want
        return true;
    }

    /// <inheritdoc />
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeof(CamelCaseConverter<>).MakeGenericType(typeToConvert);
        return (JsonConverter?)Activator.CreateInstance(converterType);
    }

    private class CamelCaseConverter<T> : JsonConverter<T>
    {
        private readonly JsonSerializerOptions _options;

        public CamelCaseConverter()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never
            };
        }

        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(ref reader, _options);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, _options);
        }
    }
}
