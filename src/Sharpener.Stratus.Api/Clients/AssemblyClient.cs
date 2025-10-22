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
public class AssemblyClient : BaseClient
{
    /// <inheritdoc />
    public AssemblyClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    /// <summary>
    ///     Gets a collection of <see cref="JsonPart" /> references related to the provided assembly.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="assemblyId">The identifier of the assembly to get the parts for.</param>
    /// <param name="configure">Optional configuration settings that come with fairly common defaults.</param>
    /// <returns>A collection of <see cref="JsonPart" />.</returns>
    public async Task<Outcome<IEnumerable<JsonPart>>> GetParts(string authToken, string assemblyId,
        Action<GetPartPageOptions>? configure = null)
    {
        var options = new GetPartPageOptions();
        configure?.Invoke(options);

        return await new PageCursor<JsonPart>(async (page, pageSize) =>
                await HttpClient.Rest()
                    .SetAppKey(authToken)
                    .SetHeader("accept", "application/json")
                    .SetPaths("v1", "assembly", assemblyId, "parts")
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
}
