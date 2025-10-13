// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Composition;
using Sharpener.Stratus.Api.Enums;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     The response type for packages.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public class StratusPackage : IIdentified, IDated
{
    /// <summary>
    ///     The identifiers of the assemblies inside the package.
    /// </summary>
    public IEnumerable<string> AssemblyIds { get; set; } = [];

    /// <summary>
    ///     The identifier of the BIM area.
    /// </summary>
    public string BimAreaId { get; set; } = string.Empty;

    /// <summary>
    ///     The sequential identifiers of CAD references.
    /// </summary>
    public IEnumerable<string> CadIdsBySequence { get; set; } = [];

    /// <summary>
    ///     The identifier of the package category.
    /// </summary>
    public string CategoryId { get; set; } = string.Empty;

    /// <summary>
    ///     Who the package was created by.
    /// </summary>
    public string CreatedBy { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the current tracking status.
    /// </summary>
    public string CurrentTrackingStatusId { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier fo the current division.
    /// </summary>
    public string CurrentDivisionId { get; set; } = string.Empty;

    /// <summary>
    ///     The package description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     The map of field identifiers to values.
    /// </summary>
    public AdditionalProps FieldIdToValueMap { get; set; } = new();

    /// <summary>
    ///     The map of field names to values.
    /// </summary>
    public AdditionalProps FieldNameToValueMap { get; set; } = new();

    /// <summary>
    ///     The optional estimated field hours.
    /// </summary>
    public double? HoursEstimatedField { get; set; }

    /// <summary>
    ///     The optional estimated office hours.
    /// </summary>
    public double? HoursEstimatedOffice { get; set; }

    /// <summary>
    ///     The optional estimated purchasing hours.
    /// </summary>
    public double? HoursEstimatedPurchasing { get; set; }

    /// <summary>
    ///     The optional estimated shop hours.
    /// </summary>
    public double? HoursEstimatedShop { get; set; }

    /// <summary>
    ///     When the package was installed.
    /// </summary>
    [JsonPropertyName("installedDT")]
    public DateTime? Installed { get; set; }

    /// <summary>
    ///     The identifier of the model to which the package belongs.
    /// </summary>
    public string ModelId { get; set; } = string.Empty;

    /// <summary>
    ///     Who the package was modified by.
    /// </summary>
    public string ModifiedBy { get; set; } = string.Empty;

    /// <summary>
    ///     The package name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     The package number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    ///     The duration of office hours involved.
    /// </summary>
    public double? OfficeDuration { get; set; }

    /// <summary>
    ///     When the office scope starts.
    /// </summary>
    [JsonPropertyName("officeStartDT")]
    public DateTime? OfficeStart { get; set; }

    /// <summary>
    ///     the identifiers of the CAD parts.
    /// </summary>
    public IEnumerable<string> PartCadIds { get; set; } = [];

    /// <summary>
    ///     The identifier of the project to which the package belongs.
    /// </summary>
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>
    ///     The duration of purchasing hours involved.
    /// </summary>
    public double? PurchasingDuration { get; set; }

    /// <summary>
    ///     When the purchasing scope starts.
    /// </summary>
    [JsonPropertyName("purchasingStartDT")]
    public DateTime? PurchasingStart { get; set; }

    /// <summary>
    ///     The url in the QR code.
    /// </summary>
    public string QrCodeUrl { get; set; } = string.Empty;

    /// <summary>
    ///     When the package is required by.
    /// </summary>
    [JsonPropertyName("requiredDT")]
    public DateTime? Required { get; set; }

    /// <summary>
    ///     The selected task workflow identifiers for the assembly CAD parts.
    /// </summary>
    public AdditionalProps SelectedTaskWorkflowIdsForAssemblyAndPartCadIds { get; set; } = new();

    /// <summary>
    ///     The amount of hours involved in the shop scope.
    /// </summary>
    public double? ShopDuration { get; set; }

    /// <summary>
    ///     When the package work starts.
    /// </summary>
    [JsonPropertyName("startDT")]
    public DateTime? Start { get; set; }

    /// <summary>
    ///     The status of the package.
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    ///     The name of the package status.
    /// </summary>
    public string StatusName { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the view that the package is associated with.
    /// </summary>
    public string ViewId { get; set; } = string.Empty;

    /// <summary>
    ///     Whether the package view identifier has been overridden.
    /// </summary>
    public bool IsViewIdOverridden { get; set; }

    /// <inheritdoc />
    [JsonPropertyName("createdDT")]
    public DateTime Created { get; set; }

    /// <inheritdoc />
    [JsonPropertyName("modifiedDT")]
    public DateTime? Modified { get; set; }

    /// <inheritdoc />
    public string Id { get; set; } = string.Empty;
}
