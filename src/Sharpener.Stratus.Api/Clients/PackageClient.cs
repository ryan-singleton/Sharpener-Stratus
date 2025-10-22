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
                .AddQueries(new
                {
                    page,
                    pagesize = pageSize,
                    options.Where,
                    options.Include,
                    options.DisableTotal
                })
                .UseRetry(options.Retry)
                .GetAsync()
                .ReadJsonAs<Page<JsonPackage>>()
                .ConfigureAwait(false))
            .GetAllPages()
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Gets a collection of <see cref="JsonPart" /> references related to the provided package.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="packageId">The identifier of the package to get the parts for.</param>
    /// <param name="configure">Optional configuration settings that come with fairly common defaults.</param>
    /// <returns>A collection of <see cref="JsonPart" />.</returns>
    public async Task<Outcome<IEnumerable<JsonPart>>> GetParts(string authToken, string packageId,
        Action<GetPartPageOptions>? configure = null)
    {
        var options = new GetPartPageOptions();
        configure?.Invoke(options);

        return await new PageCursor<JsonPart>(async (page, pageSize) =>
                await HttpClient.Rest()
                    .SetAppKey(authToken)
                    .SetHeader("accept", "application/json")
                    .SetPaths("v2", "package", packageId, "parts")
                    .AddQueries(new
                    {
                        page,
                        pagesize = pageSize,
                        options.Where,
                        options.Include,
                        options.DisableTotal,
                        options.ExcludeNullAndEmpty,
                        options.IncludeStratusProperties
                    })
                    .UseRetry(options.Retry)
                    .GetAsync()
                    .ReadJsonAs<Page<JsonPart>>()
                    .ConfigureAwait(false))
            .GetAllPages()
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Gets a bill of materials from Stratus for the specified package.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="packageId">The identifier of the package to get the bill of materials for.</param>
    /// <param name="configure">Optional configuration settings that come with fairly common defaults.</param>
    /// <returns>A <see cref="JsonBom" /> or null if the call fails.</returns>
    public async Task<Outcome<JsonBom?>> GetBom(string authToken, string packageId,
        Action<GetBomOptions>? configure = null)
    {
        var options = new GetBomOptions();
        configure?.Invoke(options);

        return await HttpClient.Rest()
            .SetAppKey(authToken)
            .SetHeader("accept", "application/json")
            .SetPaths("v1", "package", packageId, "bom")
            .AddQuery("include", options.Include)
            .UseRetry(options.Retry)
            .GetAsync()
            .ReadJsonAs<JsonBom>()
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
