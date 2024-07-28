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

public class UserServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapper = TestHelper.ConfigureMapper();

        _userService = new UserService(_unitOfWorkMock.Object, _mapper);
    }

    [Fact]
    public async Task AddAsync_AddNewUser_ReturnsSuccessfulProcess()
    {
        // arrange
        var dto = new UserDTO()
        {
            UserName = "UserName123"
        };

        _unitOfWorkMock.Setup(u => u.UserRepository.AddAsync(It.IsAny<User>()));

        // act
        await _userService.AddAsync(dto);

        // assert
        _unitOfWorkMock.Verify(u => u.UserRepository.AddAsync(It.Is<User>(m => m.UserName == dto.UserName)), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_UpdateExistingUser_ReturnsSuccessfulProcess()
    {
        // arrange
        var dto = new UserDTO()
        {
            Id = 1,
            UserName = "UserName123"
        };

        _unitOfWorkMock.Setup(u => u.UserRepository.Update(It.IsAny<User>()));

        // act
        await _userService.UpdateAsync(dto);

        // assert
        _unitOfWorkMock.Verify(u => u.UserRepository.Update(It.Is<User>(m => m.Id == dto.Id && m.UserName == dto.UserName)), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
    }
}