using AutoMapper;
using ForumApp.Data.Dtos.Forum;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class ForumProfile : Profile
{
    public ForumProfile()
    {
        CreateMap<CreateForumDto, Forum>();
        CreateMap<Forum, ReadForumDto>();
        CreateMap<Forum, UpdateForumDto>();
        CreateMap<UpdateForumDto, Forum>();
    }
}
