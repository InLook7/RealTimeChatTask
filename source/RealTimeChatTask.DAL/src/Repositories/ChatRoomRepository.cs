using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Infrastructure;
using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

namespace RealTimeChatTask.DAL.Repositories;

public class ChatRoomRepository : Repository<ChatRoom>, IChatRoomRepository
{
    public ChatRoomRepository(AppDbContext appDbContext) : base(appDbContext)
    {}
}