// The Sharpener project licenses this file to you under the MIT license.

namespace Sharpener.Stratus.Api.Composition;

/// <summary>
///     The shape of any reference that will have a created and modified date.
/// </summary>
public interface IDated
{
    /// <summary>
    ///     When the reference was created as DateTime.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    ///     When the reference was last updated as DateTime.
    /// </summary>
    public DateTime? Modified { get; set; }
}
