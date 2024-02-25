
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

Init();

builder.Services.AddBlazorBootstrap();


await builder.Build().RunAsync();

void Init()
{
}