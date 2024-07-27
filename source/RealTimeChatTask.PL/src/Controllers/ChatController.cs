using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.SharedModels.Models;
using RealTimeChatTask.BLL.DTOs;

namespace RealTimeChatTask.PL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IChatRoomService _chatRoomService;
    private readonly IMessageService _messageService;
    private readonly IUserService _userService;

    public ChatController(IMapper mapper, IChatRoomService chatRoomService, 
        IMessageService messageService, IUserService userService)
    {
        _chatRoomService = chatRoomService;
        _messageService = messageService;
        _userService = userService;
        _mapper = mapper;
    }

    // GET: api/chat/ 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChatRoomModel>>> GetRooms()
    {
        var chatRooms = await _chatRoomService.GetAllAsync();
        var chatRoomsModels = _mapper.Map<IEnumerable<ChatRoomModel>>(chatRooms);

        return Ok(chatRoomsModels);
    }

    // GET: api/chat/{roomId}/messages
    [HttpGet("{roomId}/messages")]
    public async Task<ActionResult<IEnumerable<ChatRoomModel>>> GetMessagesByRoom(int roomId)
    {
        var messages = await _messageService.GetByRoomAsync(roomId);
        var messagesModels = _mapper.Map<IEnumerable<MessageModel>>(messages);

        return Ok(messagesModels);
    }
}