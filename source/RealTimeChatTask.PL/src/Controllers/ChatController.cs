using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.PL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatRoomService _chatRoomService;
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public ChatController(IMapper mapper, IChatRoomService chatRoomService, IMessageService messageService)
    {
        _chatRoomService = chatRoomService;
        _messageService = messageService;
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
        var messages = await _messageService.GetByRoomIdAsync(roomId);
        var messagesModels = _mapper.Map<IEnumerable<MessageModel>>(messages);

        return Ok(messagesModels);
    }
}