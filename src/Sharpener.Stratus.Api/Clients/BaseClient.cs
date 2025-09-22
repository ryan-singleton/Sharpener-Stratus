using Sharpener.Rest.Extensions;

namespace Sharpener.Stratus.Api.Clients;

public class BaseClient
{
    /// <summary>
    ///     The default version of the API for endpoints to request from.
    /// </summary>
    protected const string Version = "v1";

    /// <summary>
    ///     The base url for calling the Stratus API.
    /// </summary>
    protected const string BaseUrl = "https://api.gtpstratus.com";

    /// <summary>
    ///     A message that will warn users when potentially running afoul of socket exhaustion.
    ///     https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net
    /// </summary>
    protected const string ObsoleteClientCtorMessage =
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
}
