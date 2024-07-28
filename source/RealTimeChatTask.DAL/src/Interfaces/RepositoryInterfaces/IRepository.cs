using RealTimeChatTask.DAL.Entities;

namespace RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task<TEntity> GetByIdAsync(int id);
    
    Task<TEntity> AddAsync(TEntity entity);
    
    TEntity Update(TEntity entity);
    
    Task DeleteByIdAsync(int id);
}