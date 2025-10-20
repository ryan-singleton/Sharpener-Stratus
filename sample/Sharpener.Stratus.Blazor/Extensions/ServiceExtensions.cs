// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sharpener.Stratus.Api.Clients;
using Sharpener.Stratus.Blazor.Services;

namespace Sharpener.Stratus.Blazor.Extensions;

public static class ServiceExtensions
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        WriteIndented = true, IndentCharacter = ' ', IndentSize = 2
    };

    public static IServiceCollection UseClients(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.TryAddScoped<PingClient>();
        services.TryAddScoped<ModelClient>();
        services.TryAddScoped<ProjectClient>();
        services.TryAddScoped<PackageClient>();
        services.TryAddScoped<PartClient>();
        return services;
    }

    public static IServiceCollection UseConsole(this IServiceCollection services)
    {
        services.TryAddSingleton<ConsoleService>();
        return services;
    }

    public static string WritePrettyJson<T>(this T value)
    {
        return JsonSerializer.Serialize(value, SerializerOptions);
    }
}
