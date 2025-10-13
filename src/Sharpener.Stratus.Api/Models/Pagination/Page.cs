// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Json;
using Sharpener.Stratus.Api.Models.Responses;

namespace Sharpener.Stratus.Api.Models.Pagination;

/// <summary>
///     A body for storing collections of references in paged format.
/// </summary>
/// <typeparam name="T">The type of reference that to be paginated.</typeparam>
[JsonConverter(typeof(JsonCamelCaseClass))]
public sealed class Page<T>
{
    /// <summary>
    ///     The paginated data.
    /// </summary>
    public IEnumerable<T> Data { get; set; } = [];

    /// <summary>
    ///     The current page. Start index is 0.
    /// </summary>
    public int PageOffset { get; set; }

    /// <summary>
    ///     The amount of items available per page.
    /// </summary>
    public int PageLimit { get; set; }

    /// <summary>
    ///     The amount of items on the page.
    /// </summary>
    public int PageCount { get; set; }

    /// <summary>
    ///     The total amount of items in the entire paginated collection from start to end.
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    ///     The results that have been truncated.
    /// </summary>
    public bool TruncatedResults { get; set; }

    /// <summary>
    ///     The reason that the results were truncated.
    /// </summary>
    public string TruncatedReason { get; set; } = string.Empty;

    /// <summary>
    ///     The options involved in filtration.
    /// </summary>
    public IEnumerable<FilterOption> FilterOptions { get; set; } = [];

    /// <summary>
    ///     The additional properties to the paginated data.
    /// </summary>
    public AdditionalProps Links { get; set; } = new();
}
