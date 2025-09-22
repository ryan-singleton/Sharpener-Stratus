using Sharpener.Rest.Extensions;
using Sharpener.Rest.Retry;
using Sharpener.Results;
using Sharpener.Stratus.Api.Extensions;
using Sharpener.Stratus.Api.Responses;

namespace Sharpener.Stratus.Api.Clients;

/// <summary>
///     The client for interacting with the Model endpoints on the Stratus API.
/// </summary>
public class ModelClient : BaseClient
{
    /// <inheritdoc />
    public ModelClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    /// <inheritdoc />
    [Obsolete(ObsoleteClientCtorMessage)]
    public ModelClient(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    ///     Gets a model by its model identifier.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="modelId">The identifier of the model that the report is for.</param>
    /// <param name="version">Optional. The version of the Stratus API to query. Defaults to version 1.</param>
    /// <param name="retry">The optional retry options, otherwise uses default retry backoff.</param>
    /// <returns>A <see cref="StratusModel" /> if successful.</returns>
    public async Task<Outcome<StratusModel?>> GetModel(string authToken, string modelId, string version = "v1",
        Action<RetryOptions>? retry = null)
    {
        return await HttpClient.Rest()
            .SetAppKey(authToken)
            .SetHeader("accept", "application/json")
            .SetPaths(version, "model", modelId)
            .UseRetry(retry)
            .GetAsync()
            .ReadJsonAs<StratusModel>();
    }

    /// <summary>
    ///     Generate output from report executed using Company Report ID and Model ID. Generates CSV output for PDF format
    ///     type. Only works for these Report Item Types:  Master Report, Model, Package, Package details, Assembly, or
    ///     Part.
    /// </summary>
    /// <param name="authToken">The "app-key" authorization token for the request.</param>
    /// <param name="modelId">The identifier of the model that the report is for.</param>
    /// <param name="reportId">The identifier of the report being requested.</param>
    /// <param name="viewId">Optional. The identifier for the view to further filter the report data.</param>
    /// <param name="version">Optional. The version of the Stratus API to query. Defaults to version 1.</param>
    /// <param name="retry">The optional retry options, otherwise uses default retry backoff.</param>
    /// <returns>A CSV formattable string if successful.</returns>
    public async Task<Outcome<string?>> GetModelReport(string authToken, string modelId, string reportId,
        string? viewId = null, string version = "v1", Action<RetryOptions>? retry = null)
    {
        return await HttpClient.Rest()
            .SetAppKey(authToken)
            .SetHeader("accept", "application/json")
            .SetPaths(version, "model", modelId, "report", reportId)
            .AddQuery("viewId", viewId)
            .UseRetry(retry)
            .GetAsync()
            .ReadJsonAs<string>();
    }
}
