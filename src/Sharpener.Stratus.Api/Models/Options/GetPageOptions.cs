// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Retry;

namespace Sharpener.Stratus.Api.Models.Options;

/// <inheritdoc />
public class GetPageOptions : IGetPageOptions
{
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
