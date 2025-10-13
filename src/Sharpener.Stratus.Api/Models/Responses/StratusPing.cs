// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     A response type for ping requests.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public class StratusPing
{
    /// <summary>
    ///     The optional partner application ID.
    /// </summary>
    public string AppId { get; set; } = string.Empty;

    /// <summary>
    ///     The authorization token used to ping the service.
    /// </summary>
    public string AppKey { get; set; } = string.Empty;
}
