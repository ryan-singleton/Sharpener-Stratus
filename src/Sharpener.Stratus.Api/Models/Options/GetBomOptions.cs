// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Retry;
using Sharpener.Stratus.Api.Models.Responses;

namespace Sharpener.Stratus.Api.Models.Options;

/// <summary>
///     Get options for retrieving a <see cref="JsonBom" />.
/// </summary>
public class GetBomOptions : IHasIncludeOptions, IHasRetryOptions
{
    /// <inheritdoc />
    public string? Include { get; private set; }

    /// <inheritdoc />
    public void SetIncludes(params string[] includes)
    {
        Include = string.Join(", ", includes);
    }

    /// <inheritdoc />
    public Action<RetryOptions>? Retry { get; set; }
}
