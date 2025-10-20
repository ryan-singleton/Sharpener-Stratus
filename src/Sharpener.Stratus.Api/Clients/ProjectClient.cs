// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Extensions;
using Sharpener.Results;
using Sharpener.Stratus.Api.Extensions;
using Sharpener.Stratus.Api.Models.Options;
using Sharpener.Stratus.Api.Models.Pagination;
using Sharpener.Stratus.Api.Models.Responses;

namespace Sharpener.Stratus.Api.Clients;

/// <summary>
///     The client for interacting with the Project endpoints on the Stratus API.
/// </summary>
public class ProjectClient : BaseClient
{
    /// <inheritdoc />
    public ProjectClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    /// <summary>
    ///     Gets a collection of <see cref="JsonProject" /> references that represent packages.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="configure">Optional configuration settings that come with fairly common defaults.</param>
    /// <returns>A collection of <see cref="JsonProject" />.</returns>
    public async Task<Outcome<IEnumerable<JsonProject>>> GetProjects(string authToken,
        Action<GetPageOptions>? configure = null)
    {
        var options = new GetPageOptions();
        configure?.Invoke(options);

        return await new PageCursor<JsonProject>(async (page, pageSize) => await HttpClient.Rest()
                .SetAppKey(authToken)
                .SetHeader("accept", "application/json")
                .SetPaths("v2", "project")
                .AddQueries(new { page, pagesize = pageSize, options.Where, options.Include })
                .UseRetry(options.Retry)
                .GetAsync()
                .ReadJsonAs<Page<JsonProject>>()
                .ConfigureAwait(false))
            .GetAllPages()
            .ConfigureAwait(false);
    }
}
