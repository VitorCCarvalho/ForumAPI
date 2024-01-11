using ForumApp.Data.Dtos.User;
using ForumApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUpUser(CreateUserDto dto)
    {
        await _userService.SignUp(dto);
        return Ok("User signed up");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return Ok(token);
    }
}
