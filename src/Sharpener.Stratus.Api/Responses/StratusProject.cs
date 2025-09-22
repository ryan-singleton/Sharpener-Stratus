// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Composition;

namespace Sharpener.Stratus.Api.Responses;

/// <summary>
///     The response type for projects.
/// </summary>
public class StratusProject : IHasId
{
    /// <inheritdoc />
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
}
