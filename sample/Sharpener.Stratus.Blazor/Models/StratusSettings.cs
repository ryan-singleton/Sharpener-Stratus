// The Sharpener project licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Sharpener.Stratus.Api.Json;

namespace Sharpener.Stratus.Blazor.Models;

/// <summary>
///     The settings for Stratus.
/// </summary>
[JsonConverter(typeof(JsonCamelCaseClass))]
public class StratusSettings
{
    private const string EnvVar = "STRATUS_APP_KEY";

    /// <summary>
    ///     The app key used to make requests to Stratus.
    /// </summary>
    public string AppKey
    {
        get => Environment.GetEnvironmentVariable(EnvVar, EnvironmentVariableTarget.User) ?? string.Empty;
        set => Environment.SetEnvironmentVariable(EnvVar, value, EnvironmentVariableTarget.User);
    }
}
