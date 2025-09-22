using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Composition;
using Sharpener.Stratus.Api.Enums;

namespace Sharpener.Stratus.Api.Responses;

/// <summary>
///     The response type for a model in Stratus.
/// </summary>
public class StratusModel : IHasId
{
    /// <summary>
    ///     The identifier of the folder associated with Autodesk BIM 360.
    /// </summary>
    [JsonPropertyName("a360FolderId")]
    public string Autodesk360FolderId { get; set; } = string.Empty;

    /// <summary>
    ///     When the model was created as DateTime.
    /// </summary>
    [JsonPropertyName("createdDT")]
    public DateTime Created { get; set; }

    /// <summary>
    ///     The model units according to the database.
    /// </summary>
    [JsonPropertyName("databaseUnits")]
    public UnitType Units { get; set; }

    /// <summary>
    ///     The model's default view ID.
    /// </summary>
    [JsonPropertyName("defaultViewId")]
    public string DefaultViewId { get; set; } = string.Empty;

    /// <summary>
    ///     Whether the model is associated with Field Orderz.
    /// </summary>
    [JsonPropertyName("isFieldOrderz")]
    public bool IsFieldOrderz { get; set; }

    /// <summary>
    ///     When the model was last published as DateTime.
    /// </summary>
    [JsonPropertyName("lastPublishedDT")]
    public DateTime LastPublished { get; set; }

    /// <summary>
    ///     The name of the modeling platform.
    /// </summary>
    [JsonPropertyName("modelName")]
    public string ModelPlatformName { get; set; } = string.Empty;

    /// <summary>
    ///     The type of the model.
    /// </summary>
    [JsonPropertyName("modelType")]
    public ModelType Type { get; set; }

    /// <summary>
    ///     When the model was last updated as DateTime.
    /// </summary>
    [JsonPropertyName("modifiedDT")]
    public DateTime Modified { get; set; }

    /// <summary>
    ///     The name of the model.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     The ID of the project that the model is associated with.
    /// </summary>
    [JsonPropertyName("projectId")]
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>
    ///     Which release version of the model the record is.
    /// </summary>
    [JsonPropertyName("releaseVersion")]
    public string ReleaseVersion { get; set; } = string.Empty;

    /// <inheritdoc />
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
}
