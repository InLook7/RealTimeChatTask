using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.DAL.Entities;

namespace RealTimeChatTask.BLL.Mappings;

public class BusinessLayerMapper : Profile
{
    public BusinessLayerMapper()
    {
        CreateMap<ChatRoomDTO, ChatRoom>()
            .ReverseMap();

        CreateMap<MessageDTO, Message>()
            .ReverseMap();
    }
}