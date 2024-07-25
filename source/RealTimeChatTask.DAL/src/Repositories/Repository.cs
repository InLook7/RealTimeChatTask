using Microsoft.EntityFrameworkCore;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Infrastructure;
using RealTimeChatTask.DAL.Interfaces.RepositoryInterfaces;

namespace RealTimeChatTask.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> _dbSet;
    
    public Repository(AppDbContext appDbContext)
    {
        _dbSet = appDbContext.Set<TEntity>();
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        
        return entity;
    }
    
    public TEntity Update(TEntity entity)
    {
        _dbSet.Update(entity);
        
        return entity;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        
        if(entity != null)
            _dbSet.Remove(entity);
    }
}