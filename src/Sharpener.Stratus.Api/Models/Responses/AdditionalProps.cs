// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Models.Responses;

/// <summary>
///     A common type that is returned by the Stratus API for additional property data.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public class AdditionalProps
{
    /// <summary>
    ///     The first additional property.
    /// </summary>
    public string AdditionalProp1 { get; set; } = string.Empty;

    /// <summary>
    ///     The second additional property.
    /// </summary>
    public string AdditionalProp2 { get; set; } = string.Empty;

    /// <summary>
    ///     The third additional property.
    /// </summary>
    public string AdditionalProp3 { get; set; } = string.Empty;
}
