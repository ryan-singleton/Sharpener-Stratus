// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Responses.Pagination;

[JsonConverter(typeof(CamelCaseConverterFactory))]
public class PageLinks
{
    public string AdditionalProp1 { get; set; }
    public string AdditionalProp2 { get; set; }
    public string AdditionalProp3 { get; set; }
}
