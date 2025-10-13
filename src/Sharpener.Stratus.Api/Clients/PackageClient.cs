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
public class PackageClient : BaseClient
{
    /// <inheritdoc />
    public PackageClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    /// <summary>
    ///     Gets a collection of <see cref="StratusPackage" /> references.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="configure">Optional configuration settings that come with fairly common defaults.</param>
    /// <returns>A collection of <see cref="StratusPackage" />.</returns>
    public async Task<Outcome<IEnumerable<StratusPackage>>> GetPackages(string authToken,
        Action<GetPageOptions<StratusPackage>>? configure = null)
    {
        var options = new GetPageOptions<StratusPackage>();
        configure?.Invoke(options);

        var cursor = new PageCursor<StratusPackage>(null, null, async (page, pageSize) =>
        {
            var results = await HttpClient.Rest()
                .SetAppKey(authToken)
                .SetHeader("accept", "application/json")
                .SetPaths("v1", "package")
                .AddQueries(new { page, pagesize = pageSize })
                .AddQuery("where", options.Where)
                .UseRetry(options.Retry)
                .GetAsync()
                .ReadJsonAs<Page<StratusPackage>>()
                .ConfigureAwait(false);

            return results.Value!;
        });

        var results = new List<StratusPackage>();
        while (await cursor.MoveNextAsync().ConfigureAwait(false))
        {
            results.AddRange(cursor.Current.Value.Data);
        }

        return results;
    }

    /// <summary>
    ///     Gets a package by a specific identifier.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="packageId">The identifier of the package.</param>
    /// <returns>The <see cref="StratusPackage" /> associated with the given identifier.</returns>
    public async Task<Outcome<StratusPackage?>> GetPackage(string authToken, string packageId)
    {
        return await HttpClient.Rest()
            .SetAppKey(authToken)
            .SetHeader("accept", "application/json")
            .SetPaths("v1", "package", packageId)
            .UseRetry()
            .GetAsync()
            .ReadJsonAs<StratusPackage>()
            .ConfigureAwait(false);
    }
}
