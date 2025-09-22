using Sharpener.Rest;

namespace Sharpener.Stratus.Api.Extensions;

public static class CoreExtensions
{
    public static IRestRequest SetAppKey(this IRestRequest restRequest, string appKeyToken)
    {
        return restRequest.SetHeader("app-key", appKeyToken);
    }
}
