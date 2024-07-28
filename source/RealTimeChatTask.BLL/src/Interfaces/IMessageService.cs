using RealTimeChatTask.BLL.DTOs;

namespace RealTimeChatTask.BLL.Interfaces;

public interface IMessageService : ICrud<MessageDTO>
{
    Task<IEnumerable<MessageDTO>> GetByRoomAsync(int roomId);
}