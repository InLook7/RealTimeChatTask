namespace RealTimeChatTask.Blazor.Interfaces;

public interface IChatHubService
{
    void OnReceiveMessage(Action<string> handler);
    Task StartAsync();
    Task CloseAsync();
    Task JoinChat();
    Task SendMessageAsync(string message);
}