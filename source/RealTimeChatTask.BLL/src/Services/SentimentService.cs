using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Interfaces;

namespace RealTimeChatTask.BLL.Services;

public class SentimentService : ISentimentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SentimentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SentimentDTO>> GetAllAsync()
    {
        var sentiments = await _unitOfWork.SentimentRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<SentimentDTO>>(sentiments);
    }

    public async Task<SentimentDTO> GetByIdAsync(int id)
    {
        var sentiment = await _unitOfWork.SentimentRepository.GetByIdAsync(id);
        
        return _mapper.Map<SentimentDTO>(sentiment);
    }

    public async Task<SentimentDTO> AddAsync(SentimentDTO dto)
    {
        var sentiment = _mapper.Map<Sentiment>(dto);
        
        sentiment = await _unitOfWork.SentimentRepository.AddAsync(sentiment);
        await _unitOfWork.SaveAsync();
        
        return _mapper.Map<SentimentDTO>(sentiment);
    }

    public async Task<SentimentDTO> UpdateAsync(SentimentDTO dto)
    {
        var sentiment = _mapper.Map<Sentiment>(dto);
        
        sentiment = _unitOfWork.SentimentRepository.Update(sentiment);
        await _unitOfWork.SaveAsync();
        
        return _mapper.Map<SentimentDTO>(sentiment);
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _unitOfWork.SentimentRepository.DeleteByIdAsync(id);
        await _unitOfWork.SaveAsync();
    }
}