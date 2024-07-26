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

    public bool IsConnected()
    {
        return _hubConnection.State == HubConnectionState.Connected;
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
    
    public async Task JoinChat(ChatRoomModel room)
    {
        await _hubConnection.SendAsync("JoinChat", room);
    }
    
    public async Task SendMessageAsync(ChatRoomModel room, MessageModel message)
    {
        if (!string.IsNullOrEmpty(message.Content))
        {
            await _hubConnection.SendAsync("SendMessage", room, message);
        }
    }
}