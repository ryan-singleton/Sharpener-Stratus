// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The status of projects in Stratus.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProjectStatus
{
    /// <summary>
    ///     The project is new and cannot be viewed by members until set to active.
    /// </summary>
    [Description("New")] New,

    /// <summary>
    ///     The project is active and can be viewed by members.
    /// </summary>
    [Description("Active")] Active,

    /// <summary>
    ///     The project has been archived.
    /// </summary>
    [Description("Archived")] Archived,

    /// <summary>
    ///     The project is a facility project.
    /// </summary>
    [Description("Facility")] Facility
}
