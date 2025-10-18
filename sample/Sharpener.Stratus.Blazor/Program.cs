// The Sharpener project licenses this file to you under the MIT license.

using Microsoft.Extensions.DependencyInjection.Extensions;
using Sharpener.Stratus.Blazor.Components;
using Sharpener.Stratus.Blazor.Extensions;
using Sharpener.Stratus.Blazor.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.TryAddTransient<StratusSettings>();
builder.Services.UseClients().UseConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
