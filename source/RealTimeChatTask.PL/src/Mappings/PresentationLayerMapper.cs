using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.PL.Mappings;

public class PresentationLayerMapper : Profile
{
    public PresentationLayerMapper()
    {
        CreateMap<ChatRoomModel, ChatRoomDTO>()
            .ReverseMap();

        CreateMap<MessageModel, MessageDTO>()
            .ReverseMap();
    }
}