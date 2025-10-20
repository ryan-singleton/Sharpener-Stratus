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
    ///     Gets a collection of <see cref="JsonPackage" /> references that represent packages.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="configure">Optional configuration settings that come with fairly common defaults.</param>
    /// <returns>A collection of <see cref="JsonPackage" />.</returns>
    public async Task<Outcome<IEnumerable<JsonPackage>>> GetPackages(string authToken,
        Action<GetPageOptions>? configure = null)
    {
        var options = new GetPageOptions();
        configure?.Invoke(options);

        return await new PageCursor<JsonPackage>(async (page, pageSize) => await HttpClient.Rest()
                .SetAppKey(authToken)
                .SetHeader("accept", "application/json")
                .SetPaths("v1", "package")
                .AddQueries(new { page, pagesize = pageSize, options.Where, options.Include })
                .UseRetry(options.Retry)
                .GetAsync()
                .ReadJsonAs<Page<JsonPackage>>()
                .ConfigureAwait(false))
            .GetAllPages()
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Gets a package by a specific identifier.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="packageId">The identifier of the package.</param>
    /// <returns>The <see cref="JsonProject" /> associated with the given identifier.</returns>
    public async Task<Outcome<JsonPackage?>> GetPackage(string authToken, string packageId)
    {
        return await HttpClient.Rest()
            .SetAppKey(authToken)
            .SetHeader("accept", "application/json")
            .SetPaths("v1", "package", packageId)
            .UseRetry()
            .GetAsync()
            .ReadJsonAs<JsonPackage>()
            .ConfigureAwait(false);
    }
}
