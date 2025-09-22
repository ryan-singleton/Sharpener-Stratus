// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest;

namespace Sharpener.Stratus.Api.Extensions;

/// <summary>
///     Common extension methods used throughout the Stratus API library.
/// </summary>
public static class CoreExtensions
{
    /// <summary>
    ///     Sets a "app-key" header with the provided appKey, which can be obtained from the Stratus App Key tab in the admin
    ///     section.
    /// </summary>
    /// <param name="restRequest">The rest request to add the auth header to.</param>
    /// <param name="appKeyToken">The App Key to authenticate with.</param>
    /// <returns>The rest request with the app key added to the request.</returns>
    public static IRestRequest SetAppKey(this IRestRequest restRequest, string appKeyToken)
    {
        return restRequest.SetHeader("app-key", appKeyToken);
    }
}
