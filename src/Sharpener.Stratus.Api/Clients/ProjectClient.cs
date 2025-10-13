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
    ///     Gets a collection of <see cref="StratusProject" /> references.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="configure">Optional configuration settings that come with fairly common defaults.</param>
    /// <returns>A collection of <see cref="StratusProject" />.</returns>
    public async Task<Outcome<IEnumerable<StratusProject>>> GetProjects(string authToken,
        Action<GetPageOptions<StratusProject>>? configure = null)
    {
        var options = new GetPageOptions<StratusProject>();
        configure?.Invoke(options);

        var cursor = new PageCursor<StratusProject>(null, null, async (page, pageSize) =>
        {
            var results = await HttpClient.Rest()
                .SetAppKey(authToken)
                .SetHeader("accept", "application/json")
                .SetPaths("v2", "project")
                .AddQueries(new { page, pagesize = pageSize })
                .AddQuery("where", options.Where)
                .UseRetry(options.Retry)
                .GetAsync()
                .ReadJsonAs<Page<StratusProject>>()
                .ConfigureAwait(false);

            return results.Value!;
        });

        var results = new List<StratusProject>();
        while (await cursor.MoveNextAsync().ConfigureAwait(false))
        {
            results.AddRange(cursor.Current.Value.Data);
        }

        return results;
    }
}
