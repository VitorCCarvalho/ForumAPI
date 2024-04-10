using AutoMapper;
using ForumApp.Data.Dtos.FThreadReaction;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class FThreadReactionProfile : Profile
{
    public FThreadReactionProfile()
    {
        CreateMap<CreateFThreadReactionDto, FThreadReaction>();
        CreateMap<FThreadReaction, ReadFThreadReactionDto>();
        CreateMap<UpdateFThreadReactionDto, FThreadReaction>();
        CreateMap<FThreadReaction, UpdateFThreadReactionDto>();
    }
}
