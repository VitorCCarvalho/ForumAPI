using AutoMapper;
using ForumApp.Data.Dtos.Post;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<CreatePostDto, Post>();
        CreateMap<Post, ReadPostDto>();
        CreateMap<UpdatePostDto, Post>();
        CreateMap<Post, UpdatePostDto>();
    }
}
