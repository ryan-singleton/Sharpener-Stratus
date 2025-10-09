// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Responses;

[JsonConverter(typeof(CamelCaseConverterFactory))]
public class FilterOption
{
    public bool IsValueConcatenated { get; set; }
    public string Data { get; set; }
    public IEnumerable<string> Options { get; set; }
}
