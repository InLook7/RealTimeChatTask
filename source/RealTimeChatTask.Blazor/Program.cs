using Microsoft.AspNetCore.SignalR.Client;
using RealTimeChatTask.Blazor.Components;
using RealTimeChatTask.Blazor.Services;
using RealTimeChatTask.Blazor.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<IChatHubService, ChatHubService>();
builder.Services.AddTransient<IChatApiService, ChatApiService>();

builder.Services.AddSingleton(serviceProdiver => new HttpClient
{
    BaseAddress = builder.Configuration.GetValue<Uri>("AppBackendUrl")
});

builder.Services.AddScoped(serviceProvider =>
    new HubConnectionBuilder()
        .WithUrl($"{builder.Configuration.GetValue<string>("AppBackendUrl")}/chat")
        .Build()
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
