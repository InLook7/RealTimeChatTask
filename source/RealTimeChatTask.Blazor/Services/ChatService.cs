using Microsoft.AspNetCore.SignalR.Client;
using RealTimeChatTask.Blazor.Interfaces;

namespace RealTimeChatTask.Blazor.Services;

public class ChatService : IChatService
{
	private readonly HubConnection _hubConnection;

	public ChatService(HubConnection hubConnection)
	{
		_hubConnection = hubConnection;
	}
	
	public void OnReceiveMessage(Action<string> handler)
	{
		_hubConnection.On("ReceiveMessage", handler);
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
	
	public async Task SendMessageAsync(string message)
	{
		if (!string.IsNullOrEmpty(message))
		{
			await _hubConnection.SendAsync("SendMessage", "music", message);
		}
	}
}