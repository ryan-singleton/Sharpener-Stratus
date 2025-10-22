// The Sharpener project licenses this file to you under the MIT license.

namespace Sharpener.Stratus.Api.Models.Options;

/// <summary>
///     An options object that has "includes" functionality for filtering the response to only necessary properties.
/// </summary>
public interface IHasIncludeOptions
{
    /// <summary>
    ///     A list of JSON properties to return. All remaining JSON properties will be removed from the JSON response. Example:
    ///     id, description, cutListItems. Specific dictionary keys can be included as follows: properties["Family"],
    ///     propertiesGtp["Material"].
    /// </summary>
    public string? Include { get; }

    /// <summary>
    ///     Sets a list of JSON properties to return. All remaining JSON properties will be removed from the JSON response.
    ///     Example: id, description, cutListItems. Specific dictionary keys can be included as follows: properties["Family"],
    ///     propertiesGtp["Material"].
    /// </summary>
    public void SetIncludes(params string[] includes);
}
