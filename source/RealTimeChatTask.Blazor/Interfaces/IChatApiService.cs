using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.Blazor.Interfaces;

public interface IChatApiService
{
    Task<List<ChatRoomModel>> GetAllRooms();

    Task<List<MessageModel>> GetMessagesByRoom(int roomId);

    Task<UserModel> AddUser(UserModel userModel);

    Task<UserModel> UpdateUser(UserModel userModel);
}