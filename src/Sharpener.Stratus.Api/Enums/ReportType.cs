// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The types of reports available on Stratus.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReportType
{
    /// <summary>
    ///     The report is for an assembly.
    /// </summary>
    [Description("Assembly")] Assembly,

    /// <summary>
    ///     The report is a bill of materials (BOM).
    /// </summary>
    [Description("BOM")] BillOfMaterials,

    /// <summary>
    ///     The report is for a container.
    /// </summary>
    [Description("Container")] Container,

    /// <summary>
    ///     The report is for container details.
    /// </summary>
    [Description("ContainerDetails")] ContainerDetails,

    /// <summary>
    ///     The report is for an invoice.
    /// </summary>
    [Description("Invoice")] Invoice,

    /// <summary>
    ///     The report is a master report of other reports.
    /// </summary>
    [Description("MasterReport")] Master,

    /// <summary>
    ///     The report is for a package.
    /// </summary>
    [Description("Package")] Package,

    /// <summary>
    ///     The report is for the details of a package.
    /// </summary>
    [Description("PackageDetails")] PackageDetails,

    /// <summary>
    ///     The report is for a part.
    /// </summary>
    [Description("Part")] Part,

    /// <summary>
    ///     The report is for purchasing.
    /// </summary>
    [Description("Purchasing")] Purchasing,

    /// <summary>
    ///     The report is for a report and template configuration grid.
    /// </summary>
    [Description("ReportAndTemplateConfigurationGrid")]
    ReportAndTemplateConfigurationGrid
}
