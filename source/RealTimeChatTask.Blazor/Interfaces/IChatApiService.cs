using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.Blazor.Interfaces;

public interface IChatApiService
{
    Task<List<ChatRoomModel>> GetAllRooms();

    Task<List<MessageModel>> GetMessagesByRoom(int roomId);
}