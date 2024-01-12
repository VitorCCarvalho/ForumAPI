using AutoMapper;
using ForumApp.Data.Dtos.FThread;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class FThreadProfile : Profile
{
    public FThreadProfile()
    {
        CreateMap<CreateFThreadDto, FThread>();
        CreateMap<FThread, ReadFThreadDto>();
        CreateMap<UpdateFThreadDto, FThread>();
    }
}
