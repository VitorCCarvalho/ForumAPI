using AutoMapper;
using ForumApp.Data.Dtos.Forum;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class ForumProfile : Profile
{
    public ForumProfile()
    {
        CreateMap<CreateForumDto, Forum>();
        CreateMap<Forum, UpdateForumDto>();
        CreateMap<UpdateForumDto, Forum>();
        CreateMap<Forum, ReadForumDto>()
            .ForMember(forumdto => forumdto.Threads,
                opt => opt.MapFrom(forum => forum.Threads));
    }
}
