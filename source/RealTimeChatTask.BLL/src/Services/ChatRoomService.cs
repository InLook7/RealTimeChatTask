using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Interfaces;

namespace RealTimeChatTask.BLL.Services;

public class ChatRoomService : IChatRoomService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ChatRoomService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ChatRoomDTO>> GetAllAsync()
    {
        var chatRooms = await _unitOfWork.ChatRoomRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<ChatRoomDTO>>(chatRooms);
    }

    public async Task<ChatRoomDTO> GetByIdAsync(int id)
    {
        var chatRoom = await _unitOfWork.ChatRoomRepository.GetByIdAsync(id);
        
        return _mapper.Map<ChatRoomDTO>(chatRoom);
    }
    
    public async Task<ChatRoomDTO> AddAsync(ChatRoomDTO dto)
    {
        var chatRoom = _mapper.Map<ChatRoom>(dto);
        
        chatRoom = await _unitOfWork.ChatRoomRepository.AddAsync(chatRoom);
        await _unitOfWork.SaveAsync();
        
        return _mapper.Map<ChatRoomDTO>(chatRoom);
    }
    
    public async Task<ChatRoomDTO> UpdateAsync(ChatRoomDTO dto)
    {
        var chatRoom = _mapper.Map<ChatRoom>(dto);
        
        chatRoom = _unitOfWork.ChatRoomRepository.Update(chatRoom);
        await _unitOfWork.SaveAsync();
        
        return _mapper.Map<ChatRoomDTO>(chatRoom);
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _unitOfWork.ChatRoomRepository.DeleteByIdAsync(id);
        await _unitOfWork.SaveAsync();
    }
}