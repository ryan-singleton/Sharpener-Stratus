// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Stratus.Blazor.Extensions;

namespace Sharpener.Stratus.Blazor.Services;

public class ConsoleService
{
    public string? Output { get; private set; }

    public event Action? OnChange;

    public void WriteToConsole(string description, object? value)
    {
        if (value is null)
        {
            return;
        }

        Output = string.IsNullOrWhiteSpace(Output)
            ? $"{description}{Environment.NewLine}{value.WritePrettyJson()}"
            : $"{Output},{Environment.NewLine}{description}{Environment.NewLine}{value.WritePrettyJson()}";

        OnChange?.Invoke();
    }

    public void Clear()
    {
        Output = null;
        OnChange?.Invoke();
    }
}
