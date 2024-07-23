using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Interfaces;

namespace RealTimeChatTask.BLL.Services;

public class MessageService : IMessageService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	
	public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}
	
	public async Task<IEnumerable<MessageDTO>> GetAllAsync()
	{
		var messages = await _unitOfWork.MessageRepository.GetAllAsync();
		
		return _mapper.Map<IEnumerable<MessageDTO>>(messages);
	}

	public async Task<MessageDTO> GetByIdAsync(int id)
	{
		var message = await _unitOfWork.MessageRepository.GetByIdAsync(id);
		
		return _mapper.Map<MessageDTO>(message);
	}
	
	public async Task<MessageDTO> AddAsync(MessageDTO dto)
	{
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