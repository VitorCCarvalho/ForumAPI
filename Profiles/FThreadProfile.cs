using AutoMapper;
using ForumApp.Data.Dtos.FThread;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class FThreadProfile : Profile
{
    public FThreadProfile()
    {
        CreateMap<CreateFThreadDto, FThread>();
        CreateMap<UpdateFThreadDto, FThread>();
        CreateMap<FThread, ReadFThreadDto>()
            .ForMember(fthreadDto => fthreadDto.Posts,
                opt => opt.MapFrom(fthread => fthread.Posts));
    }
}
