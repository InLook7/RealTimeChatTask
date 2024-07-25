using Microsoft.AspNetCore.SignalR.Client;
using RealTimeChatTask.Blazor.Components;
using RealTimeChatTask.Blazor.Services;
using RealTimeChatTask.Blazor.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<IChatService, ChatService>();

builder.Services.AddSingleton(serviceProvider =>
{
    return new HubConnectionBuilder()
        .WithUrl("http://localhost:12000/chat")
        .Build();
});

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
