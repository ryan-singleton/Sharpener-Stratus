// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Extensions;
using Sharpener.Results;
using Sharpener.Stratus.Api.Models.Options;
using Sharpener.Stratus.Api.Models.Pagination;
using Sharpener.Stratus.Api.Models.Responses;

namespace Sharpener.Stratus.Api.Clients;

/// <summary>
///     The base client with shared behavior among all other endpoint-based clients.
/// </summary>
public class BaseClient
{
    /// <summary>
    ///     The default version of the API for endpoints to request from.
    /// </summary>
    protected const string Version = "v1";

    /// <summary>
    ///     The base url for calling the Stratus API.
    /// </summary>
    private const string BaseUrl = "https://api.gtpstratus.com";

    /// <summary>
    ///     A message that will warn users when potentially running afoul of socket exhaustion.
    ///     https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net
    /// </summary>
    private const string ObsoleteClientCtorMessage =
        "The constructor that accepts an IHttpClientFactory is recommended as it follows Microsoft's recommended approach to HTTP request formation.";

    /// <summary>
    ///     The HttpClient for making requests.
    /// </summary>
    protected readonly HttpClient HttpClient;

    /// <summary>
    ///     Constructor of a new Stratus API client using an <see cref="IHttpClientFactory" />.
    /// </summary>
    /// <param name="httpClientFactory">The factory that manages the <see cref="HttpClient" /> pool.</param>
    protected BaseClient(IHttpClientFactory httpClientFactory)
    {
        HttpClient = httpClientFactory.CreateUrlClient(BaseUrl);
    }

    /// <summary>
    ///     Constructor of a new Stratus API client that uses a manually provided <see cref="HttpClient" />.
    /// </summary>
    [Obsolete(ObsoleteClientCtorMessage)]
    protected BaseClient(HttpClient httpClient)
    {
        httpClient.SetBaseAddress(BaseUrl);
        HttpClient = httpClient;
    }

    /// <summary>
    ///     Gets all pages for a specific HTTP Request to the Stratus API.
    /// </summary>
    /// <param name="func">The HTTP request to run per page.</param>
    /// <param name="configure">The optional configuration for the request.</param>
    /// <returns>A collection of responses.</returns>
    protected static async Task<Outcome<IEnumerable<T>>> GetAllPages<T>(
        Func<int, int, GetPageOptions<T>, Task<Outcome<Page<T>?>>> func,
        Action<GetPageOptions<T>>? configure = null) where T : IJsonResponse
    {
        var options = new GetPageOptions<T>();
        configure?.Invoke(options);

        var cursor = new PageCursor<T>(null, null, async (page, pageSize) =>
        {
            var results = await func(page, pageSize, options).ConfigureAwait(false);
            return results.Value!;
        });

        var results = new List<T>();
        while (await cursor.MoveNextAsync().ConfigureAwait(false))
        {
            results.AddRange(cursor.Current.Value.Data);
        }

        return results;
    }
}
