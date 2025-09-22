using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Composition;
using Sharpener.Stratus.Api.Enums;

namespace Sharpener.Stratus.Api.Responses;

/// <summary>
///     A response type for reports.
/// </summary>
public class StratusReport : IHasId
{
    /// <summary>
    ///     The name of the report.
    /// </summary>
    [JsonPropertyName("name")]
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
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
}
