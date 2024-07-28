using Microsoft.AspNetCore.SignalR;
using FluentValidation;
using AutoMapper;
using RealTimeChatTask.PL.Interfaces;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.PL.Hubs;

public class ChatHub : Hub<IChatClient>
{
    private readonly ITextAnalyticsService _textAnalyticsService;
    private readonly ISentimentService _sentimentService;
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public ChatHub(ITextAnalyticsService textAnalyticsService, ISentimentService sentimentService,
        IMessageService messageService, IMapper mapper)
    {
        _textAnalyticsService = textAnalyticsService;
        _sentimentService = sentimentService;
        _messageService = messageService;
        _mapper = mapper;
    } 

    public async Task JoinChat(ChatRoomModel room)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, room.Name);
    }

    public async Task SendMessage(ChatRoomModel room, MessageModel messageModel)
    {
        var messageDTO = _mapper.Map<MessageDTO>(messageModel);

        try
        {
            var message = await _messageService.AddAsync(messageDTO);
            
            var sentiment = await _textAnalyticsService.AnalyzeSentimentAsync(message.Content);
            await _sentimentService.AddAsync(new SentimentDTO()
            {
                MessageId = message.Id,
                SentimentResult = sentiment.Sentiment.ToString(),
                PositiveScore = sentiment.ConfidenceScores.Positive,
                NeutralScore = sentiment.ConfidenceScores.Neutral,
                NegativeScore = sentiment.ConfidenceScores.Negative
            });

            message = await _messageService.GetByIdAsync(message.Id);

            await Clients.Group(room.Name).ReceiveMessage(_mapper.Map<MessageModel>(message));
        }
        catch (ValidationException)
        {
            await Clients.Caller.ReceiveError("Your message must not contain more than one hundred characters.", messageModel.Content);
        }
    }
}