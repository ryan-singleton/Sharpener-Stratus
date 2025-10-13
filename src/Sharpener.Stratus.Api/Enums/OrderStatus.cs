// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The status of orders in Stratus.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    /// <summary>
    ///     The order is active.
    /// </summary>
    [Description(nameof(Active))] Active,

    /// <summary>
    ///     The order is archived.
    /// </summary>
    [Description(nameof(Archived))] Archived
}
