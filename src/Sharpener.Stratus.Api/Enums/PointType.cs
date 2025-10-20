// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The type of specific point in Stratus.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PointType
{
    /// <summary>
    ///     Unspecified point type.
    /// </summary>
    [Description(nameof(Unspecified))] Unspecified = 0,

    /// <summary>
    ///     A connector point.
    /// </summary>
    [Description(nameof(Connector))] Connector = 1,

    /// <summary>
    ///     An anchoring point.
    /// </summary>
    [Description(nameof(Anchor))] Anchor = 2,

    /// <summary>
    ///     A GTP point.
    /// </summary>
    /// <remarks>
    ///     Often used for survey.
    /// </remarks>
    [Description("GTP")] Gtp = 3,

    /// <summary>
    ///     A wall point.
    /// </summary>
    [Description(nameof(Wall))] Wall = 4,

    /// <summary>
    ///     A point indicting the center of something.
    /// </summary>
    [Description(nameof(Centroid))] Centroid = 5,

    /// <summary>
    ///     A point marking the connection of a tap.
    /// </summary>
    [Description("Tap Connector")] TapConnector = 6,

    /// <summary>
    ///     A point representing the centerline of an intersection.
    /// </summary>
    [Description("Centerline Intersection")]
    CenterlineIntersection = 7,

    /// <summary>
    ///     A point representing a dimension reference.
    /// </summary>
    [Description("Dimension Reference")] DimensionReference = 8,

    /// <summary>
    ///     A point for positioning.
    /// </summary>
    [Description(nameof(Positioning))] Positioning = 9,

    /// <summary>
    ///     A point for the snapping functionality.
    /// </summary>
    [Description("Snapper Point")] SnapperPoint = -9999,

    /// <summary>
    ///     A snap point for intersections.
    /// </summary>
    [Description("Snap Intersection")] SnapIntersection = -9909,

    /// <summary>
    ///     A snap point for faces.
    /// </summary>
    [Description("Snap Face")] SnapFace = -9904,

    /// <summary>
    ///     A snap point for edges.
    /// </summary>
    [Description("Snap Edge")] SnapEdge = -9903,

    /// <summary>
    ///     A snap point for the center of circles.
    /// </summary>
    [Description("Snap Circle Center")] SnapCircleCenter = -9902,

    /// <summary>
    ///     A snap point for midpoints.
    /// </summary>
    [Description("Snap Midpoint")] SnapMidpoint = -9901,

    /// <summary>
    ///     A snap point for vertices.
    /// </summary>
    [Description("Snap Vertex")] SnapVertex = -9900
}
