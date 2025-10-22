// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Enums;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     Represents a line item within a Stratus BOM, containing detailed part and material information.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public class StratusBomLineItem
{
    /// <summary>
    ///     The collection of CAD identifiers grouped under this line item.
    /// </summary>
    public IEnumerable<string> GroupedPartCadIds { get; set; } = [];

    /// <summary>
    ///     The sequence number of the line item in the BOM.
    /// </summary>
    public int? Sequence { get; set; }

    /// <summary>
    ///     Indicates whether the item is modeled in the CAD system.
    /// </summary>
    public bool? IsModeled { get; set; }

    /// <summary>
    ///     Indicates whether the item is reportable in the BOM.
    /// </summary>
    public bool? IsReportable { get; set; }

    /// <summary>
    ///     Indicates whether the item is consolidated with other similar items.
    /// </summary>
    public bool? IsConsolidated { get; set; }

    /// <summary>
    ///     The name of the item's manufacturer.
    /// </summary>
    public string Manufacturer { get; set; } = string.Empty;

    /// <summary>
    ///     The quantity of the item required.
    /// </summary>
    public double? Quantity { get; set; }

    /// <summary>
    ///     The size specification of the item.
    /// </summary>
    public string Size { get; set; } = string.Empty;

    /// <summary>
    ///     A textual description of the item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     The material from which the item is made.
    /// </summary>
    public string Material { get; set; } = string.Empty;

    /// <summary>
    ///     The product code associated with the item.
    /// </summary>
    public string ProductCode { get; set; } = string.Empty;

    /// <summary>
    ///     The diameter of the item, if applicable.
    /// </summary>
    public string Diameter { get; set; } = string.Empty;

    /// <summary>
    ///     The width of the item, if applicable.
    /// </summary>
    public string Width { get; set; } = string.Empty;

    /// <summary>
    ///     The length of the item, if applicable.
    /// </summary>
    public string Length { get; set; } = string.Empty;

    /// <summary>
    ///     Indicates whether the item's length can be nested for fabrication.
    /// </summary>
    public bool? IsLengthNestable { get; set; }

    /// <summary>
    ///     The nominal stock length of the item.
    /// </summary>
    public string NominalStockLength { get; set; } = string.Empty;

    /// <summary>
    ///     An additional property or note associated with the item.
    /// </summary>
    public string AdditionalProperty { get; set; } = string.Empty;

    /// <summary>
    ///     The unit of measure used for the item.
    /// </summary>
    public MarketplaceUnitOfMeasure UnitOfMeasure { get; set; }

    /// <summary>
    ///     The name of the unit of measure.
    /// </summary>
    public string UnitOfMeasureName { get; set; } = string.Empty;

    /// <summary>
    ///     A comment or note related to the item.
    /// </summary>
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    ///     Indicates whether the item is not purchased.
    /// </summary>
    public bool? NotPurchased { get; set; }

    /// <summary>
    ///     Indicates whether the item is considered ancillary.
    /// </summary>
    public bool? IsAncillary { get; set; }

    /// <summary>
    ///     The name of the service associated with the item.
    /// </summary>
    public string ServiceName { get; set; } = string.Empty;

    /// <summary>
    ///     The code of the service associated with the item.
    /// </summary>
    public string ServiceCode { get; set; } = string.Empty;

    /// <summary>
    ///     A JSON object containing possible supplier codes for the item.
    /// </summary>
    public JsonObject PossibleSupplierCodes { get; set; } = new();
}
