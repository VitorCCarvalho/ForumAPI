using AutoMapper;
using ForumApp.Data.Dtos.PostReaction;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class PostReactionProfile : Profile
{
    public PostReactionProfile()
    {
        CreateMap<CreatePostReactionDto, PostReaction>();
        CreateMap<PostReaction, ReadPostReactionDto>();
        CreateMap<UpdatePostReactionDto, PostReaction>();
        CreateMap<PostReaction, UpdatePostReactionDto>();
    }
}
