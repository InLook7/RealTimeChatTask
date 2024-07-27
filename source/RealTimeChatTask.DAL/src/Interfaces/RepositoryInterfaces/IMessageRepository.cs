using RealTimeChatTask.DAL.Entities;

namespace RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

public interface IMessageRepository : IRepository<Message>
{
    Task<IEnumerable<Message>> GetAllByRoomWithDetailsAsync(int roomId);

    Task<Message> GetByIdWithDetailsAsync(int id);
}