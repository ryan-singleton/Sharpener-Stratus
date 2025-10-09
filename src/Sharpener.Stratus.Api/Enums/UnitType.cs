// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     Unit types for measurement.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UnitType
{
    /// <summary>
    ///     Imperial measurement units.
    /// </summary>
    [Description("Imperial")] Imperial,

    /// <summary>
    ///     Metric measurement units.
    /// </summary>
    [Description("Metric")] Metric
}
