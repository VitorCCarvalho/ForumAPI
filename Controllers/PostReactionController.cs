using AutoMapper;
using ForumApp.Data.Dtos.FThread;
using ForumApp.Data.Dtos.PostReaction;
using ForumApp.Data;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using ForumApp.Data.Dtos.Post;
using ForumApp.Data.Dtos.FThreadReaction;

namespace ForumApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PostReactionController : ControllerBase
{
    private ForumContext _context;
    private IMapper _mapper;

    public PostReactionController(ForumContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostFPostReaction([FromBody] CreatePostReactionDto dto)
    {
        PostReaction postReaction = _mapper.Map<PostReaction>(dto);
        _context.Add(postReaction);
        _context.SaveChanges();
        return Created("Post Reaction Created", postReaction);
    }

    [HttpGet]
    public IEnumerable<ReadPostReactionDto> GetPostReactions([FromQuery] int? postId, [FromQuery] int take = 50)
    {
        if (postId == null)
        {
            return _mapper.Map<List<ReadPostReactionDto>>(_context.PostReaction.Take(take).ToList());
        }
        else
        {
            return _mapper.Map<List<ReadPostReactionDto>>(_context.PostReaction.Take(take).
                                                        Where(postReaction => postReaction.PostId == postId).ToList());
        }
    }

    [HttpGet("{postId}")]
    public IEnumerable<ReadPostReactionDto> GetFThreadReactionPorFThread(int postId, [FromQuery] string? reaction)
    {
        if (reaction == "like")
        {
            return _mapper.Map<List<ReadPostReactionDto>>(_context.PostReaction.Where(postReaction => postReaction.PostId == postId & postReaction.Reaction == true).ToList());
        }
        else if (reaction == "dislike")
        {
            return _mapper.Map<List<ReadPostReactionDto>>(_context.PostReaction.Where(postReaction => postReaction.PostId == postId & postReaction.Reaction == false).ToList());
        }
        else
        {
            return _mapper.Map<List<ReadPostReactionDto>>(_context.PostReaction.Where(postReaction => postReaction.PostId == postId).ToList());
        }
    }

    [HttpGet("{postId}/{userId}")]
    public ReadPostReactionDto GetPostReaction(int postId, string UserId)
    {
        return _mapper.Map<ReadPostReactionDto>(_context.PostReaction.FirstOrDefault(postReaction => postReaction.PostId == postId & postReaction.UserId == UserId));
    }

    [HttpPut("{fthreadId}/{userId}")]
    public IActionResult PutPostReaction([FromQuery] int postId, [FromQuery] string UserId, [FromBody] UpdatePostDto dto)
    {
        var fthreadReaction = _context.PostReaction.FirstOrDefault(fthreadReaction => fthreadReaction.PostId == postId & fthreadReaction.UserId == UserId);
        if (fthreadReaction == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, fthreadReaction);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{fthreadId}/{userId}")]
    public IActionResult DeleteFThread(int postId, string UserId)
    {
        var postReaction = _context.PostReaction.FirstOrDefault(postReaction => postReaction.PostId == postId & postReaction.UserId == UserId);
        if (postReaction == null)
        {
            return NotFound();
        }
        _context.Remove(postReaction);
        _context.SaveChanges();
        return NoContent();
    }
}
