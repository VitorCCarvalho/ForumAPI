using AutoMapper;
using ForumApp.Data;
using ForumApp.Data.Dtos.Comment;
using ForumApp.Data.Dtos.Forum;
using ForumApp.Data.Dtos.Post;
using ForumApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    ForumContext _context;
    private IMapper _mapper;

    public CommentController(ForumContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostComment([FromBody] CreateCommentDto dto)
    {
        Comment comment = _mapper.Map<Comment>(dto);
        _context.Add(comment);
        _context.SaveChanges();
        return Created("Comment created", comment);
    }

    [HttpGet]
    public IEnumerable<ReadCommentDto> GetComments([FromQuery] int? PostId, [FromQuery] int take = 50)
    {
        if(PostId == null)
        {
            return _mapper.Map<List<ReadCommentDto>>(_context.Comments.Take(take).ToList());
        }
        else
        {
            return _mapper.Map<List<ReadCommentDto>>(_context.Comments.Take(take).
                                                    Where(comment => comment.PostId == PostId));
        }

    }

    [HttpPut("{commentId}")]
    public IActionResult PutComment(int commentId, [FromBody] UpdatePostDto dto)
    {
        var post = _context.Comments.FirstOrDefault(comment => comment.Id == commentId);
        if (post == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, post);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{commentId}")]
    public IActionResult PatchComment(int commentId, JsonPatchDocument<UpdateCommentDto> patch)
    {
        var comment = _context.Comments.FirstOrDefault(comment => comment.Id == commentId);
        if (comment == null)
        {
            return NotFound();
        }

        var postPatch = _mapper.Map<UpdateCommentDto>(comment);
        patch.ApplyTo(postPatch, ModelState);

        if (!TryValidateModel(postPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(postPatch, comment);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteComment(int commentId)
    {
        var comment = _context.Forums.FirstOrDefault(comment => comment.Id == commentId);
        if (comment == null)
        {
            return NotFound();
        }
        _context.Remove(comment);
        _context.SaveChanges();
        return NoContent();
    }

}
