using Xunit;
using Moq;
using AutoMapper;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.BLL.Services;
using RealTimeChatTask.DAL.Entities;
using RealTimeChatTask.DAL.Interfaces;

namespace RealTimeChatTask.Tests.UnitTests;

public class ChatRoomServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;
    private readonly IChatRoomService _chatRoomService;

    public ChatRoomServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapper = TestHelper.ConfigureMapper();

        _chatRoomService = new ChatRoomService(_unitOfWorkMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllAsync_GetAllRooms_ReturnsRooms()
    {
        // arrange
        var rooms = new List<ChatRoom>
        {
            new ChatRoom() { Name = "Music" },
            new ChatRoom() { Name = "Reading" },
            new ChatRoom() { Name = "Sport" },
            new ChatRoom() { Name = "Science" },
        };

        _unitOfWorkMock.Setup(u => u.ChatRoomRepository.GetAllAsync())
            .ReturnsAsync(rooms);

        // act
        var actual = await _chatRoomService.GetAllAsync();

        // assert
        _unitOfWorkMock.Verify(u => u.ChatRoomRepository.GetAllAsync(), Times.Once);
        Assert.NotNull(actual);
        Assert.Equal(rooms.Count, actual.Count());
    } 
}