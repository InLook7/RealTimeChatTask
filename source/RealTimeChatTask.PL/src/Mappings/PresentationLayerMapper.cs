using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.PL.Mappings;

public class PresentationLayerMapper : Profile
{
    public PresentationLayerMapper()
    {
        CreateMap<ChatRoomDTO, ChatRoomModel>()
            .ReverseMap();

        CreateMap<MessageDTO, MessageModel>()
            .ReverseMap();

        CreateMap<UserDTO, UserModel>()
            .ReverseMap();
    }
}