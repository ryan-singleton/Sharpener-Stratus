// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Retry;

namespace Sharpener.Stratus.Api.Models.Options;

/// <summary>
///     The options type for getting paginated items.
/// </summary>
public class GetPageOptions<T>
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

    /// <summary>
    ///     Optional retry logic. There is already a recommended default that retries 3 times with a backoff.
    /// </summary>
    public Action<RetryOptions>? Retry { get; set; }
}
