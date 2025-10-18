// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest;
using Sharpener.Rest.Extensions;
using Sharpener.Rest.Retry;
using Sharpener.Results;
using Sharpener.Stratus.Api.Extensions;
using Sharpener.Stratus.Api.Models.Responses;

namespace Sharpener.Stratus.Api.Clients;

/// <summary>
///     The client for interacting with the Ping endpoints on the Stratus API.
/// </summary>
public class PingClient : BaseClient
{
    private string _partnerAppId = string.Empty;

    /// <inheritdoc />
    public PingClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    /// <summary>
    ///     A simple way to test the connection to the Stratus API.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="version">Optional. The version of the API to query. Defaults to <see cref="Version" /></param>
    /// <param name="retry">The optional retry options, otherwise uses default retry backoff.</param>
    /// <returns>A <see cref="JsonPing" /> if successful.</returns>
    public async Task<Outcome<JsonPing?>> Ping(string authToken, string version = Version,
        Action<RetryOptions>? retry = null)
    {
        return await MaybeSetPartnerAppHeader(HttpClient.Rest())
            .SetAppKey(authToken)
            .SetHeader("accept", "*/*")
            .SetPaths(version, "ping")
            .UseRetry(retry)
            .GetAsync()
            .ReadJsonAs<JsonPing>()
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     The optional partner application ID. This is reserved for the use of partner applications.
    /// </summary>
    /// <remarks>
    ///     If you don't know what this is, you probably do not need to worry about it.
    /// </remarks>
    /// <param name="partnerAppId"></param>
    public void SetPartnerAppId(string partnerAppId)
    {
        _partnerAppId = partnerAppId;
    }

    private IRestRequest MaybeSetPartnerAppHeader(IRestRequest restRequest)
    {
        if (!string.IsNullOrEmpty(_partnerAppId))
        {
            restRequest.SetHeader("app-id", _partnerAppId);
        }

        return restRequest;
    }
}
