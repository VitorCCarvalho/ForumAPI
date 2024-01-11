using AutoMapper;
using ForumApp.Data.Dtos.User;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
