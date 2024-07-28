using RealTimeChatTask.BLL.DTOs;

namespace RealTimeChatTask.BLL.Interfaces;

public interface ICrud<TDTO> where TDTO : BaseDTO
{
    Task<IEnumerable<TDTO>> GetAllAsync();
    
    Task<TDTO> GetByIdAsync(int id);
    
    Task<TDTO> AddAsync(TDTO dto);
    
    Task<TDTO> UpdateAsync(TDTO dto);
    
    Task DeleteByIdAsync(int id);
}