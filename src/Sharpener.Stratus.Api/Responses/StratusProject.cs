// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Composition;
using Sharpener.Stratus.Api.Enums;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Api.Responses;

/// <summary>
///     The response type for projects.
/// </summary>
[JsonConverter(typeof(CamelCaseConverterFactory))]
public class StratusProject : IIdentified, IDated
{
    /// <summary>
    ///     The status of the project.
    /// </summary>
    public ProjectStatus Status { get; set; }

    /// <summary>
    ///     The name of the status of the project.
    /// </summary>
    public string StatusName { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier for the project on Autodesk 360.
    /// </summary>
    [JsonPropertyName("a360Id")]
    public string Autodesk360Id { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier for the project's root folder on Autodesk 360.
    /// </summary>
    [JsonPropertyName("a360RootFolderId")]
    public string Autodesk360RootFolderId { get; set; } = string.Empty;

    /// <summary>
    ///     The identifier of the company associated with the project.
    /// </summary>
    public string CompanyId { get; set; } = string.Empty;

    /// <summary>
    ///     The project category.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    ///     The project number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    ///     The project name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     The project phase.
    /// </summary>
    public string Phase { get; set; } = string.Empty;

    /// <summary>
    ///     The project description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     The attachment ID of the image associated with the project.
    /// </summary>
    public string ImageAttachmentId { get; set; } = string.Empty;

    /// <summary>
    ///     The main address of the project.
    /// </summary>
    [JsonPropertyName("address1")]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    ///     The extended address information of the project.
    /// </summary>
    [JsonPropertyName("address2")]
    public string AddressExtended { get; set; } = string.Empty;

    /// <summary>
    ///     The city in which the project is taking place.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    ///     The state in which the project is taking place.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    ///     The zip code in which the project is taking place.
    /// </summary>
    public string Zip { get; set; } = string.Empty;

    /// <summary>
    ///     The intended start date of the project.
    /// </summary>
    public DateTime TargetStartDate { get; set; }

    /// <summary>
    ///     The actual start date of the project.
    /// </summary>
    public DateTime ActualStartDate { get; set; }

    /// <summary>
    ///     The intended completion date of the project.
    /// </summary>
    public DateTime TargetEndDate { get; set; }

    /// <summary>
    ///     The actual completion date of the project.
    /// </summary>
    public DateTime ActualEndDate { get; set; }

    /// <summary>
    ///     The color associated with the project in Stratus.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    ///     Whether the project is tax-exempt.
    /// </summary>
    public bool IsTaxExempt { get; set; }

    /// <inheritdoc />
    [JsonPropertyName("createdDT")]
    public DateTime Created { get; set; }

    /// <inheritdoc />
    [JsonPropertyName("modifiedDT")]
    public DateTime Modified { get; set; }

    /// <inheritdoc />
    public string Id { get; set; } = string.Empty;
}
