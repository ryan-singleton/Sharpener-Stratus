// The Sharpener project licenses this file to you under the MIT license.

namespace Sharpener.Stratus.Api.Models.Options;

/// <summary>
///     The options type for getting paginated items.
/// </summary>
public interface IPaginationOptions
{
    /// <summary>
    ///     The optional parameter to indicate which page of results to obtain. Defaults to 0, which is the start page.
    /// </summary>
    public int? StartPage { get; set; }

    /// <summary>
    ///     The optional parameter to indicate how many results to receive per page. Defaults to 1000, which is also the
    ///     maximum.
    /// </summary>
    public int? PageSize { get; set; }

    /// <summary>
    ///     Optional: disable total calculation to improve performance (default is false)
    /// </summary>
    public bool DisableTotal { get; }
}
