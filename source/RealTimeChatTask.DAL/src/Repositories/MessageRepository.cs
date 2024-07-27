using Microsoft.EntityFrameworkCore;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Infrastructure;
using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

namespace RealTimeChatTask.DAL.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(AppDbContext appDbContext) : base(appDbContext)
    {}

    public async Task<IEnumerable<Message>> GetAllByRoomWithSentimentsAsync(int roomId)
    {
        return await _dbSet
            .Include(m => m.Sentiment)
            .Where(m => m.ChatRoomId == roomId)
            .ToListAsync();
    }

    public async Task<Message> GetByIdWithSentimentsAsync(int id)
    {
        return await _dbSet
            .Include(m => m.Sentiment)
            .SingleOrDefaultAsync(m => m.Id == id);
    }
}