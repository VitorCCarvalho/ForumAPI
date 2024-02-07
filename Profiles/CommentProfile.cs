using AutoMapper;
using ForumApp.Data.Dtos.Comment;
using ForumApp.Models;

namespace ForumApp.Profiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<Comment, ReadCommentDto>();
        CreateMap<UpdateCommentDto, Comment>();
        CreateMap<Comment, UpdateCommentDto>();
    }
    

}
