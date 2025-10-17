// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Nodes;
using Sharpener.Rest.Extensions;
using Sharpener.Results;
using Sharpener.Stratus.Api.Extensions;
using Sharpener.Stratus.Api.Models.Options;
using Sharpener.Stratus.Api.Models.Pagination;

namespace Sharpener.Stratus.Api.Clients;

/// <summary>
///     The client for interacting with the Part endpoints on the Stratus API.
/// </summary>
public class PartClient : BaseClient
{
    /// <inheritdoc />
    public PartClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    /// <summary>
    ///     Gets a collection of <see cref="JsonObject" /> references that represent parts.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="configure">Optional configuration settings that come with fairly common defaults.</param>
    /// <returns>A collection of <see cref="JsonObject" />.</returns>
    public async Task<Outcome<IEnumerable<JsonObject>>> GetParts(string authToken,
        Action<GetPageOptions<JsonObject>>? configure = null)
    {
        var options = new GetPageOptions<JsonObject>();
        configure?.Invoke(options);

        var cursor = new PageCursor<JsonObject>(null, null, async (page, pageSize) =>
        {
            var results = await HttpClient.Rest()
                .SetAppKey(authToken)
                .SetHeader("accept", "application/json")
                .SetPaths("v1", "part")
                .AddQueries(new { page, pagesize = pageSize, options.Where, options.Include })
                .UseRetry(options.Retry)
                .GetAsync()
                .ReadJsonAs<Page<JsonObject>>()
                .ConfigureAwait(false);

            return results.Value!;
        });

        var results = new List<JsonObject>();
        while (await cursor.MoveNextAsync().ConfigureAwait(false))
        {
            results.AddRange(cursor.Current.Value.Data);
        }

        return results;
    }
}
