using Xunit;
using Moq;
using AutoMapper;
using FluentValidation;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Services;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Interfaces;

namespace RealTimeChatTask.Tests.UnitTests;

public class MessageServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;
    private readonly IValidator<MessageDTO> _validator;
    private readonly IMessageService _messageService;

    public MessageServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapper = TestHelper.ConfigureMapper();
        _validator = Mock.Of<IValidator<MessageDTO>>();

        _messageService = new MessageService(_unitOfWorkMock.Object, _mapper, _validator);
    }    

    [Fact]
    public async Task AddAsync_AddNewMessage_ReturnsSuccessfulProcess()
    {
        // arrange
        var dto = new MessageDTO()
        {
            ChatRoomId = 1,
            UserId = 1,
            Content = "Hello!",
            CreationDate = DateTime.UtcNow,
        };

        _unitOfWorkMock.Setup(u => u.MessageRepository.AddAsync(It.IsAny<Message>()));

        // act
        await _messageService.AddAsync(dto);

        // assert
        _unitOfWorkMock.Verify(u => u.MessageRepository.AddAsync(It.Is<Message>(m => m.Content == dto.Content)), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
    }

    [Fact]
    public async Task GetByRoomAsync_GetAllMessagesByRoomId_ReturnsMessages()
    {
        // arrange
        var roomId = 1;
        var messages = new List<Message>
        {
            new Message() { ChatRoomId = 1, Content = "Test1" },
            new Message() { ChatRoomId = 1, Content = "Test2" },
            new Message() { ChatRoomId = 1, Content = "Test3" }
        };

        _unitOfWorkMock.Setup(u => u.MessageRepository.GetAllByRoomWithDetailsAsync(roomId))
            .ReturnsAsync(messages);

        // act
        var actual = await _messageService.GetByRoomAsync(roomId);

        // assert
        _unitOfWorkMock.Verify(u => u.MessageRepository.GetAllByRoomWithDetailsAsync(roomId), Times.Once);
        Assert.NotNull(actual);
        Assert.Equal(messages.Count, actual.Count());
    }
}