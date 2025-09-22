using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Responses;

public class StratusPing
{
    /// <summary>
    ///     The optional partner application ID.
    /// </summary>
    [JsonPropertyName("appId")]
    public string AppId { get; set; } = string.Empty;

    /// <summary>
    ///     The authorization token used to ping the service.
    /// </summary>
    [JsonPropertyName("appKey")]
    public string AppKey { get; set; } = string.Empty;
}
