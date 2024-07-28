using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Interfaces;

namespace RealTimeChatTask.BLL.Services;

public class UserService : IUserService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
        
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> AddAsync(UserDTO dto)
    {
        var user = _mapper.Map<User>(dto);
        
        user = await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveAsync();
        
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> UpdateAsync(UserDTO dto)
    {
        var user = _mapper.Map<User>(dto);
        
        user = _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.SaveAsync();
        
        return _mapper.Map<UserDTO>(user);
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _unitOfWork.UserRepository.DeleteByIdAsync(id);
        await _unitOfWork.SaveAsync();
    }
}