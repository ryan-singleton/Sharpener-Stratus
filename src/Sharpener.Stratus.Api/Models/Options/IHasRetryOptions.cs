// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Retry;

namespace Sharpener.Stratus.Api.Models.Options;

/// <summary>
///     An options type that contains optional retry customization logic.
/// </summary>
public interface IHasRetryOptions
{
    /// <summary>
    ///     Optional retry logic. There is already a recommended default that retries 3 times with a backoff.
    /// </summary>
    public Action<RetryOptions>? Retry { get; set; }
}
