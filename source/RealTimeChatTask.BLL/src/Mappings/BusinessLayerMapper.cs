using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.DAL.Entities;

namespace RealTimeChatTask.BLL.Mappings;

public class BusinessLayerMapper : Profile
{
    public BusinessLayerMapper()
    {
        CreateMap<ChatRoom, ChatRoomDTO>()
            .ReverseMap();

        CreateMap<Message, MessageDTO>()
            .ForMember(dto => dto.Sentiment, c => c.MapFrom(entity => entity.Sentiment.SentimentResult));
        
        CreateMap<MessageDTO, Message>();
        
        CreateMap<Sentiment, SentimentDTO>()
            .ReverseMap();
    }
}