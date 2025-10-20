// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Retry;

namespace Sharpener.Stratus.Api.Models.Options;

/// <inheritdoc />
public class GetPartPageOptions : IGetPageOptions
{
    /// <summary>
    ///     Pass true to this optional query parameter if you want to generate STRATUS.Part.* properties and have them returned
    ///     for the parts. When in use, query must be limited to a single model id. Defaults to false.
    /// </summary>
    public bool IncludeStratusProperties { get; set; }

    /// <summary>
    ///     Pass true to this optional query parameter if you want empty or null values removed from the part's Properties and
    ///     PropertiesGtp collections to improve performance. Defaults to false.
    /// </summary>
    public bool ExcludeNullAndEmpty { get; set; }

    /// <inheritdoc />
    public int? StartPage { get; set; }

    /// <inheritdoc />
    public int? PageSize { get; set; }

    /// <inheritdoc />
    public string? Where { get; set; }

    /// <inheritdoc />
    public string? Include { get; private set; }

    /// <inheritdoc />
    public Action<RetryOptions>? Retry { get; set; }

    /// <inheritdoc />
    public void SetIncludes(params string[] includes)
    {
        Include = string.Join(", ", includes);
    }
}
