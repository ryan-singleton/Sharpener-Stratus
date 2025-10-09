// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Responses.Pagination;

[JsonConverter(typeof(CamelCaseConverterFactory))]
public class Page<T>
{
    public IEnumerable<T> Data { get; set; }
    public int PageOffset { get; set; }
    public int PageLimit { get; set; }
    public int PageCount { get; set; }
    public int Total { get; set; }
    public bool TruncatedResults { get; set; }
    public string TruncatedReason { get; set; }
    public IEnumerable<FilterOption> FilterOptions { get; set; }
    public PageLinks Links { get; set; }
}
