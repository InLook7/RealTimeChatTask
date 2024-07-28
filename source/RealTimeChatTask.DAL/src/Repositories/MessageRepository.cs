using Microsoft.EntityFrameworkCore;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Infrastructure;
using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

namespace RealTimeChatTask.DAL.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(AppDbContext appDbContext) : base(appDbContext)
    {}

    public async Task<IEnumerable<Message>> GetAllByRoomWithDetailsAsync(int roomId)
    {
        return await _dbSet
            .Include(m => m.Sentiment)
            .Include(m => m.User)
            .Where(m => m.ChatRoomId == roomId)
            .ToListAsync();
    }

    public async Task<Message> GetByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(m => m.Sentiment)
            .Include(m => m.User)
            .SingleOrDefaultAsync(m => m.Id == id);
    }
}