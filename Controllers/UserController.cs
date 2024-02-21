using AutoMapper;
using ForumApp.Data.Dtos.Post;
using ForumApp.Data.Dtos.User;
using ForumApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    /// <summary>
    /// Cadastra um User novo.
    /// </summary>
    [HttpPost("signup")]
    public async Task<IActionResult> SignUpUser(CreateUserDto dto)
    {
        await _userService.SignUp(dto);
        return Ok("User signed up");
    }

    /// <summary>
    /// Verifica se o user existe e retorna token de sessão jwt.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return Ok(token);
    }

    /// <summary>
    /// Retorna todos Users.
    /// </summary>
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(string userId)
    {
        var user = await _userService.GetUser(userId);
        return Ok(user);
    }
}
