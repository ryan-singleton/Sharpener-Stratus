// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The report formats available on Stratus.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReportFormat
{
    /// <summary>
    ///     The report is in CSV format.
    /// </summary>
    [Description("CSV")] Csv,

    /// <summary>
    ///     The report is in PDF format.
    /// </summary>
    [Description("PDF")] Pdf,

    /// <summary>
    ///     The report is in ZPL label format.
    /// </summary>
    [Description("ZPL")] Zpl
}
