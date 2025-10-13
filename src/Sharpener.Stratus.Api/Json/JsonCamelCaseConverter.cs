// The Sharpener project licenses this file to you under the MIT license.

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Extensions;

namespace Sharpener.Stratus.Api.Json;

/// <summary>
///     A converter that forces a class to be serialized and deserialized as camel case by default.
/// </summary>
/// <typeparam name="T">The type that should be camel case.</typeparam>
public sealed class JsonCamelCaseConverter<T> : JsonConverter<T> where T : class, new()
{
    private static readonly PropertyInfo[] Properties = typeof(T)
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(p => p.GetMethod != null || p.SetMethod != null)
        .ToArray();

    /// <inheritdoc />
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        var model = new T();

        foreach (var prop in Properties)
        {
            if (prop.IsDefined(typeof(JsonIgnoreAttribute)))
            {
                continue;
            }

            if (!prop.CanWrite)
            {
                continue;
            }

            var jsonNameAttr = prop.GetCustomAttribute<JsonPropertyNameAttribute>();
            var jsonPropName = jsonNameAttr?.Name ?? prop.Name.ToLowerStart();

            if (!root.TryGetProperty(jsonPropName, out var element))
            {
                continue;
            }

            var value = element.Deserialize(prop.PropertyType, options);

            prop.SetValue(model, value);
        }

        return model;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartObject();

        foreach (var prop in Properties)
        {
            if (prop.IsDefined(typeof(JsonIgnoreAttribute)))
            {
                continue;
            }

            if (!prop.CanRead)
            {
                continue;
            }

            var propValue = prop.GetValue(value);
            var jsonNameAttr = prop.GetCustomAttribute<JsonPropertyNameAttribute>();
            var propName = jsonNameAttr?.Name ?? prop.Name.ToLowerStart();

            var defaultIgnore = options.DefaultIgnoreCondition;
            switch (defaultIgnore)
            {
                case JsonIgnoreCondition.WhenWritingNull when propValue == null:
                case JsonIgnoreCondition.WhenWritingDefault when IsDefault(propValue, prop.PropertyType):
                    continue;
            }

            writer.WritePropertyName(propName);

            if (propValue is null)
            {
                writer.WriteNullValue();
            }
            else
            {
                JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
            }
        }

        writer.WriteEndObject();
    }

    private static bool IsDefault(object? value, Type type)
    {
        if (!type.IsValueType)
        {
            return value is null;
        }

        var defaultValue = Activator.CreateInstance(type)!;
        return Equals(value, defaultValue);
    }
}
