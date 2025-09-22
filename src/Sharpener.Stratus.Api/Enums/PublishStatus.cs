// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The status of a publish operation for data.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PublishStatus
{
    /// <summary>
    ///     The data is published.
    /// </summary>
    Published,

    /// <summary>
    ///     The data was recently published.
    /// </summary>
    PostPublish,

    /// <summary>
    ///     The data is publishing.
    /// </summary>
    Publishing,

    /// <summary>
    ///     Translation of the data failed.
    /// </summary>
    TranslationFailed,

    /// <summary>
    ///     Translation of the data timed out.
    /// </summary>
    TranslationTimedOut,

    /// <summary>
    ///     The publish operation failed.
    /// </summary>
    Failed,

    /// <summary>
    ///     The publish operation was initiated.
    /// </summary>
    PublishInitiated
}
