using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.PL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    // POST: api/user
    [HttpPost]
    public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel userModel)
    {
        var user = _mapper.Map<UserDTO>(userModel);

        user = await _userService.AddAsync(user);

        return Ok(_mapper.Map<UserModel>(user));
    }

    // PUT: api/user
    [HttpPut]
    public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel)
    {
        var user = _mapper.Map<UserDTO>(userModel);

        user = await _userService.UpdateAsync(user);

        return Ok(_mapper.Map<UserModel>(user));
    }
}