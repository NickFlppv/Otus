using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otus.Contracts;
using Otus.Contracts.Requests;
using Otus.Domain.Users;
using Otus.Service.Logic.Users;

namespace Otus.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersLogic _usersLogic;
    private readonly IMapper _mapper;

    public UsersController(IUsersLogic usersLogic, IMapper mapper)
    {
        _usersLogic = usersLogic;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(long userId)
    {
        var user = await _usersLogic.GetUserById(userId);

        if (user is null)
        {
            return NotFound();
        }
        
        var userDto = _mapper.Map<User, UserResponse>(user);

        return Ok(userDto);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRequest userDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Required form fields are not filled or invalid");
        
        var user = _mapper.Map<UserRequest, User>(userDto);

        var userId = await _usersLogic.Register(user);
        
        return Ok(userId);
    }
}