using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.Blazor.Interfaces;

public interface IChatHubService
{
    void OnReceiveMessage(Action<MessageModel> handler);
    void OnReceiveError(Action<string, string> handler);
    Task StartAsync();
    Task CloseAsync();
    Task JoinChat();
    Task SendMessageAsync(MessageModel message);
}