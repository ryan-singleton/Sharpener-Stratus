// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Composition;
using Sharpener.Stratus.Api.Enums;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     The response type for parts.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public class StratusPart : IIdentified, IDated
{
    /// <summary>
    ///     When the part was cut if it can be cut.
    /// </summary>
    public DateTime? CutDateTime { get; set; }

    /// <summary>
    ///     The identifier of the project that the part is associated with.
    /// </summary>
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>
    ///     The name of the project that the part is associated with.
    /// </summary>
    public string ProjectName { get; set; } = string.Empty;

    /// <summary>
    ///     The number of the project that the part is associated with, often a customer-specific value.
    /// </summary>
    public string ProjectNumber { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the model that the part is associated with.
    /// </summary>
    public string ModelId { get; set; } = string.Empty;

    /// <summary>
    ///     The name of the model that the part is associated with.
    /// </summary>
    public string ModelName { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the BIM area that the part is associated with.
    /// </summary>
    public string BimAreaId { get; set; } = string.Empty;

    /// <summary>
    ///     The BIM area that the part is associated with. Such as "Roof".
    /// </summary>
    public string BimArea { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the part as it pertains to the <see cref="CadType" />.
    /// </summary>
    public string CadId { get; set; } = string.Empty;

    /// <summary>
    ///     The part type when modeled.
    /// </summary>
    public string CadType { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the part for use on the web.
    /// </summary>
    public string WebId { get; set; } = string.Empty;

    /// <summary>
    ///     The part description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the current tracking status.
    /// </summary>
    public string CurrentTrackingStatusId { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the current division associated with the part.
    /// </summary>
    public string CurrentDivisionId { get; set; } = string.Empty;

    /// <summary>
    ///     All the properties associated to the part, can be custom for the customer.
    /// </summary>
    public JsonObject Properties { get; set; } = new();

    /// <summary>
    ///     All the properties associated to the part that are built in by Stratus GTP.
    /// </summary>
    public JsonObject PropertiesGtp { get; set; } = new();

    /// <summary>
    ///     The geometric and location data of the part.
    /// </summary>
    public IEnumerable<Point3D> Points { get; set; } = [];

    /// <summary>
    ///     A cut length adjustment for the part.
    /// </summary>
    public double CutLengthAdjustment { get; set; }

    /// <summary>
    ///     A secondary cut length adjustment value for the part.
    /// </summary>
    public double CutLength2Adjustment { get; set; }

    /// <summary>
    ///     Whether to lock the length.
    /// </summary>
    public bool? LockLength { get; set; }

    /// <summary>
    ///     Whether to lock the location.
    /// </summary>
    public bool? LockLocation { get; set; }

    /// <summary>
    ///     The url in the QR code.
    /// </summary>
    public string QrCodeUrl { get; set; } = string.Empty;

    /// <summary>
    ///     The url to the part.
    /// </summary>
    public string PartUrl { get; set; } = string.Empty;

    /// <summary>
    ///     The pattern number of the part.
    /// </summary>
    /// <remarks>
    ///     This can refer to the "CID" or "Pattern Number" often found in Autodesk Fabrication, for example.
    /// </remarks>
    public string PatternNumber { get; set; } = string.Empty;

    /// <summary>
    ///     The type of the part source, often reflecting the source platform that it was authored in.
    /// </summary>
    public PartSourceType Source { get; set; }

    /// <summary>
    ///     The map of field identifiers to values.
    /// </summary>
    public JsonObject FieldIdToValueMap { get; set; } = new();

    /// <summary>
    ///     The map of field names to values.
    /// </summary>
    public JsonObject FieldNameToValueMap { get; set; } = new();

    /// <inheritdoc />
    [JsonPropertyName("createdDT")]
    public DateTime Created { get; set; }

    /// <inheritdoc />
    [JsonPropertyName("modifiedDT")]
    public DateTime? Modified { get; set; }

    /// <inheritdoc />
    public string Id { get; set; } = string.Empty;
}
