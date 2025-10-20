// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Models;

/// <summary>
///     A vector class type used in Stratus.
/// </summary>
public class Vector
{
    /// <summary>
    ///     The X value.
    /// </summary>
    [JsonPropertyName("x")]
    public double X { get; set; }

    /// <summary>
    ///     The Y value.
    /// </summary>
    [JsonPropertyName("y")]
    public double Y { get; set; }

    /// <summary>
    ///     The Z value.
    /// </summary>
    [JsonPropertyName("z")]
    public double Z { get; set; }
}
