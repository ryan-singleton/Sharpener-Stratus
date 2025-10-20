// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The source type for Stratus parts.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PartSourceType
{
    /// <summary>
    ///     A published model is the source of the part.
    /// </summary>
    [Description("Published Model")] PublishedModel,

    /// <summary>
    ///     Field Orderz is the source of the part.
    /// </summary>
    [Description("Field Orderz")] FieldOrderz,

    /// <summary>
    ///     A lightning catalog is the source of the part.
    /// </summary>
    [Description("Lightning Catalog")] LightningCatalog,

    /// <summary>
    ///     An Autodesk cloud platform is the source of the part.
    /// </summary>
    [Description("Autodesk Cloud")] AutodeskCloud
}
