using Microsoft.AspNetCore.SignalR;
using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.PL.Hubs;

public class ChatHub : Hub
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public ChatHub(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    } 

    public async Task JoinChat(string group)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
    }
    
    public async Task SendMessage(string group, MessageModel messageModel)
    {
        var messageDTO = _mapper.Map<MessageDTO>(messageModel);

        var message = await _messageService.AddAsync(messageDTO);

        await Clients.Group(group).SendAsync("ReceiveMessage", _mapper.Map<MessageModel>(message));
    }
}