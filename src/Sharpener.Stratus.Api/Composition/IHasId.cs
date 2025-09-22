// The Sharpener project licenses this file to you under the MIT license.

namespace Sharpener.Stratus.Api.Composition;

/// <summary>
///     The shape of any reference that will contain an Id property.
/// </summary>
public interface IHasId
{
    /// <summary>
    ///     The universally unique identifier of the reference.
    /// </summary>
    public string Id { get; }
}
