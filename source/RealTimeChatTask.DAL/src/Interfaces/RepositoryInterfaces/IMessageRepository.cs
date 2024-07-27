using RealTimeChatTask.DAL.Entities;

namespace RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

public interface IMessageRepository : IRepository<Message>
{
    Task<IEnumerable<Message>> GetAllByRoomWithSentimentsAsync(int roomId);

    Task<Message> GetByIdWithSentimentsAsync(int id);
}