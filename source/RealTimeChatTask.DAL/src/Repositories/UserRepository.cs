using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Infrastructure;
using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

namespace RealTimeChatTask.DAL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {}
}