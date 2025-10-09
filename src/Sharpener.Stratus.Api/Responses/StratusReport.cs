// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Composition;
using Sharpener.Stratus.Api.Enums;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Responses;

/// <summary>
///     A response type for reports.
/// </summary>
[JsonConverter(typeof(CamelCaseConverterFactory))]
public class StratusReport : IIdentified
{
    /// <summary>
    ///     The name of the report.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     The format of the report.
    /// </summary>
    [JsonPropertyName("formatTypeName")]
    public ReportFormat Format { get; set; }

    /// <summary>
    ///     The type of the report.
    /// </summary>
    [JsonPropertyName("itemTypeName")]
    public ReportType Type { get; set; }

    /// <inheritdoc />
    public string Id { get; set; } = string.Empty;
}
