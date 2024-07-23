using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Infrastructure;
using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

namespace RealTimeChatTask.DAL.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(AppDbContext appDbContext) : base(appDbContext)
    {}
}