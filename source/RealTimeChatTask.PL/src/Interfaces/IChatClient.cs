using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.PL.Interfaces;

public interface IChatClient
{
    Task ReceiveMessage(MessageModel message);
    Task ReceiveError(string error, string content);
}