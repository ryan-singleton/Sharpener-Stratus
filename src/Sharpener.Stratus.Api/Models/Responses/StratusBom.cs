// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Composition;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     Represents a BOM from Stratus.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public class StratusBom : IIdentified
{
    /// <summary>
    ///     The unique identifier of the division associated with the BOM.
    /// </summary>
    public string DivisionId { get; set; } = string.Empty;

    /// <summary>
    ///     The unique identifier of the project associated with the BOM.
    /// </summary>
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>
    ///     The unique identifier of the model associated with the BOM.
    /// </summary>
    public string ModelId { get; set; } = string.Empty;

    /// <summary>
    ///     The unique identifier of the package associated with the BOM.
    /// </summary>
    public string PackageId { get; set; } = string.Empty;

    /// <summary>
    ///     The date and time when the BOM is required.
    /// </summary>
    [JsonPropertyName("requiredDT")]
    public DateTime? Required { get; set; }

    /// <summary>
    ///     Indicates whether the BOM is locked.
    /// </summary>
    public bool? IsLocked { get; set; }

    /// <summary>
    ///     The date and time when the BOM was generated.
    /// </summary>
    [JsonPropertyName("generatedDT")]
    public DateTime? Generated { get; set; }

    /// <summary>
    /// The line items of the bill of materials.
    /// </summary>
    public IEnumerable<StratusBomLineItem> LineItems { get; set; } = [];

    /// <summary>
    ///     The date and time when the BOM was locked.
    /// </summary>
    [JsonPropertyName("lockedDT")]
    public DateTime? Locked { get; set; }

    /// <summary>
    ///     The name of the user who locked the BOM.
    /// </summary>
    public string LockedByName { get; set; } = string.Empty;

    /// <summary>
    ///     The date and time when the BOM was unlocked.
    /// </summary>
    [JsonPropertyName("unlockedDT")]
    public DateTime? Unlocked { get; set; }

    /// <summary>
    ///     The name of the user who unlocked the BOM.
    /// </summary>
    public string UnlockedByName { get; set; } = string.Empty;

    /// <inheritdoc />
    public string Id { get; } = string.Empty;
}
