// The Sharpener project licenses this file to you under the MIT license.

namespace Sharpener.Stratus.Api.Models.Options;

/// <summary>
///     An options object that has "where" functionality for filtering the response to only the filtered results.
/// </summary>
public interface IHasWhereOptions
{
    /// <summary>
    ///     A lambda filter for the results, this filter will be run on the server side, not the client, and can help to reduce
    ///     bandwidth usage and increase performance.
    /// </summary>
    /// <remarks>
    ///     Per the API Docs:<br />
    ///     Filter on JSON property values. Example: To filter on two JSON properties: length eq '10' AND description ==
    ///     "truck". To get the last 30 days of data, use: createdDT ge DateTime.Now.AddDays(-30)<br />
    ///     <br />
    ///     We need to build an expression visitor for this, but we also need a full listing of options for this where syntax.
    /// </remarks>
    public string? Where { get; set; }
}
