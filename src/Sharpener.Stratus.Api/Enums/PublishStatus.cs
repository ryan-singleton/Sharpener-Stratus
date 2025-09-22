using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PublishStatus
{
    Published
}
