using AutoMapper;
using FluentValidation;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Interfaces;

namespace RealTimeChatTask.BLL.Services;

public class MessageService : IMessageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<MessageDTO> _validator;
    
    public MessageService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<MessageDTO> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }
    
    public async Task<IEnumerable<MessageDTO>> GetAllAsync()
    {
        var messages = await _unitOfWork.MessageRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<MessageDTO>>(messages);
    }

    public async Task<MessageDTO> GetByIdAsync(int id)
    {
        var message = await _unitOfWork.MessageRepository.GetByIdWithDetailsAsync(id);
        
        return _mapper.Map<MessageDTO>(message);
    }

    public async Task<IEnumerable<MessageDTO>> GetByRoomAsync(int roomId)
    {
        var messages = await _unitOfWork.MessageRepository.GetAllByRoomWithDetailsAsync(roomId);

        return _mapper.Map<IEnumerable<MessageDTO>>(messages);
    }
    
    public async Task<MessageDTO> AddAsync(MessageDTO dto)
    {
        await _validator.ValidateAndThrowAsync(dto);
        var message = _mapper.Map<Message>(dto);
        
        message = await _unitOfWork.MessageRepository.AddAsync(message);
        await _unitOfWork.SaveAsync();
        
        return _mapper.Map<MessageDTO>(message);
    }
    
    public async Task<MessageDTO> UpdateAsync(MessageDTO dto)
    {
        var message = _mapper.Map<Message>(dto);
        
        message = _unitOfWork.MessageRepository.Update(message);
        await _unitOfWork.SaveAsync();
        
        return _mapper.Map<MessageDTO>(message);
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _unitOfWork.MessageRepository.DeleteByIdAsync(id);
        await _unitOfWork.SaveAsync();
    }
}