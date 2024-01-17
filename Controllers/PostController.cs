using AutoMapper;
using ForumApp.Data;
using ForumApp.Data.Dtos.Forum;
using ForumApp.Data.Dtos.Post;
using ForumApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    ForumContext _context;
    private IMapper _mapper;

    public PostController(ForumContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostFPost([FromBody] CreatePostDto dto)
    {
        Post post = _mapper.Map<Post>(dto);
        _context.Add(post);
        _context.SaveChanges();
        return Created("Post created", post);
    }

    [HttpGet]
    public IEnumerable<ReadPostDto> GetPosts([FromQuery] int? ThreadId, [FromQuery] int take = 50)
    {
        if(ThreadId == null)
        {
            return _mapper.Map<List<ReadPostDto>>(_context.Posts.Take(take).ToList());
        }
        else
        {
            return _mapper.Map<List<ReadPostDto>>(_context.Posts.Take(take).
                                                    Where(post => post.ThreadId == ThreadId));
        }
    }

    [HttpPut("{postId}")]
    public IActionResult PutForum(int postId, [FromBody] UpdatePostDto dto)
    {
        var post = _context.Forums.FirstOrDefault(post => post.Id == postId);
        if (post == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, post);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{postId}")]
    public IActionResult PatchForum(int postId, JsonPatchDocument<UpdateForumDto> patch)
    {
        var post = _context.Forums.FirstOrDefault(post => post.Id == postId);
        if (post == null)
        {
            return NotFound();
        }

        var postPatch = _mapper.Map<UpdateForumDto>(post);
        patch.ApplyTo(postPatch, ModelState);

        if (!TryValidateModel(postPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(postPatch, post);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePost(int postId)
    {
        var post = _context.Forums.FirstOrDefault(post => post.Id == postId);
        if (post == null)
        {
            return NotFound();
        }
        _context.Remove(post);
        _context.SaveChanges();
        return NoContent();
    }
}
