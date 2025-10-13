// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     Options for filtration.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public sealed class FilterOption
{
    /// <summary>
    ///     Whether the value is concatenated.
    /// </summary>
    public bool IsValueConcatenated { get; set; }

    /// <summary>
    ///     The filtration data.
    /// </summary>
    public string Data { get; set; } = string.Empty;

    /// <summary>
    ///     The filter options.
    /// </summary>
    public IEnumerable<string> Options { get; set; } = [];
}
