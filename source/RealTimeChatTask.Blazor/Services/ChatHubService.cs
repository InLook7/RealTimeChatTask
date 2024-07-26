using Microsoft.AspNetCore.SignalR.Client;
using RealTimeChatTask.Blazor.Interfaces;
using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.Blazor.Services;

public class ChatHubService : IChatHubService
{
    private readonly HubConnection _hubConnection;

    public ChatHubService(HubConnection hubConnection)
    {
        _hubConnection = hubConnection;
    }
    
    public void OnReceiveMessage(Action<MessageModel> handler)
    {
        _hubConnection.On("ReceiveMessage", handler);
    }  

    public void OnReceiveError(Action<string, string> handler)
    {
        _hubConnection.On("ReceiveError", handler);
    } 
    
    public async Task StartAsync()
    {
        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            await _hubConnection.StartAsync();
        }
    }
    
    public async Task CloseAsync()
    {
        if (_hubConnection.State == HubConnectionState.Connected)
        {
            await _hubConnection.StopAsync();
        }
    }
    
    public async Task JoinChat()
    {
        await _hubConnection.SendAsync("JoinChat", "music");
    }
    
    public async Task SendMessageAsync(MessageModel message)
    {
        if (!string.IsNullOrEmpty(message.Content))
        {
            await _hubConnection.SendAsync("SendMessage", "music", message);
        }
    }
}