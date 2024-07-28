using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Infrastructure;
using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

namespace RealTimeChatTask.DAL.Repositories;

public class SentimentRepository : Repository<Sentiment>, ISentimentRepository
{
    public SentimentRepository(AppDbContext appDbContext) : base(appDbContext)
    {}
}