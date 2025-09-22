// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Responses;

/// <summary>
///     A response type for ping requests.
/// </summary>
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
