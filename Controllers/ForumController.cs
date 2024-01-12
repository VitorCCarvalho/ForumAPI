using AutoMapper;
using ForumApp.Data;
using ForumApp.Data.Dtos.Forum;
using ForumApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ForumController : ControllerBase
{
    private ForumContext _context;
    private IMapper _mapper;

    public ForumController(ForumContext forumContext, IMapper mapper)
    {
        _context = forumContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostForum([FromBody] CreateForumDto dto)
    {
        Forum forum = _mapper.Map<Forum>(dto);
        _context.Add(forum);
        _context.SaveChanges();
        return Created("Forum created", forum);
    }

    [HttpGet]
    public IEnumerable<ReadForumDto> GetForums([FromQuery] int take = 50,[FromQuery] string? nomeForum = null)
    {
        if(nomeForum == null)
        {
            return _mapper.Map<List<ReadForumDto>>(_context.Forums.Take(take).ToList());
        }
        else
        {
            return _mapper.Map<List<ReadForumDto>>(_context.Forums.Take(take).
                                                    Where(forum => forum.Name == nomeForum));
        }
    }

    [HttpPut("{name}")]
    public IActionResult PutForum(string name, [FromBody] UpdateForumDto dto)
    {
        var forum = _context.Forums.FirstOrDefault(forum => forum.Name == name);
        if(forum == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, forum);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{name}")]
    public IActionResult PatchForum(string name, JsonPatchDocument<UpdateForumDto> patch)
    {
        var forum = _context.Forums.FirstOrDefault(forum => forum.Name == name);
        if (forum == null)
        {
            return NotFound();
        }
        var forumPatch = _mapper.Map<UpdateForumDto>(forum);
        patch.ApplyTo(forumPatch, ModelState);

        if (!TryValidateModel(forumPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(forumPatch, forum);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{name}")]
    public IActionResult DeleteForum(string name)
    {
        var forum = _context.Forums.FirstOrDefault(forum => forum.Name == name);
        if (forum == null)
        {
            return NotFound();
        }
        _context.Remove(forum);
        _context.SaveChanges();
        return NoContent();
    }

    
}
