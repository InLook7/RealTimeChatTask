using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.Blazor.Interfaces;

public interface IChatHubService
{
    void OnReceiveMessage(Action<MessageModel> handler);

    void OnReceiveError(Action<string, string> handler);

    bool IsConnected();

    Task StartAsync();

    Task CloseAsync();

    Task JoinChat(ChatRoomModel room);

    Task SendMessageAsync(ChatRoomModel room, MessageModel message);
}