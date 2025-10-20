// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Enums;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     Represents a 3D point in space in the Stratus modeling environment.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public class Point3D
{
    /// <summary>
    ///     The type of the point.
    /// </summary>
    [JsonPropertyName("pointType")]
    public PointType Type { get; set; }

    /// <summary>
    ///     The identifier of the point in the model.
    /// </summary>
    public string CadId { get; set; } = string.Empty;

    /// <summary>
    ///     A point that indicates positional coordinates in space.
    /// </summary>
    public Vector Location { get; set; } = new();

    /// <summary>
    ///     A point used to indicate a directional vector to establish orientation of the point.
    /// </summary>
    public Vector Direction { get; set; } = new();

    /// <summary>
    ///     The vector that establishes which way is up.
    /// </summary>
    /// <remarks>
    ///     Largely useful for establishing a rotation axis.
    /// </remarks>
    [JsonPropertyName("upVector")]
    public Vector Up { get; set; } = new();

    /// <summary>
    ///     The width of the point.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    ///     The height of the point.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    ///     The identifier of the element to which this point may be coupled, such as in situations of connectors.
    /// </summary>
    public string MatingElementUniqueId { get; set; } = string.Empty;
}
