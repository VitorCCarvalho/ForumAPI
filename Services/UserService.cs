using AutoMapper;
using ForumApp.Data.Dtos.User;
using ForumApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ForumApp.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }



    public async Task SignUp(CreateUserDto dto)
    {
        User user = _mapper.Map<User>(dto);

        IdentityResult resultado = await _userManager.CreateAsync(user, dto.Password);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }

    internal async Task<string> Login(LoginUserDto dto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded)
        {
            return "unauthorized";
        }

        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.GenerateToken(user);

        return token;
    }

    public async Task<ReadUserDto> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userMap = _mapper.Map<ReadUserDto>(user);
            return userMap;
        }
        else
        {
            throw new ApplicationException("Usuário não encontrado");
        }
    }
}
