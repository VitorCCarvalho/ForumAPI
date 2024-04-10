using AutoMapper;
using ForumApp.Data;
using ForumApp.Data.Dtos.FThread;
using ForumApp.Data.Dtos.FThreadReaction;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;

[ApiController]
[Route("[controller]")]
public class FThreadReactionController : ControllerBase
{
    private ForumContext _context;
    private IMapper _mapper;

    public FThreadReactionController(ForumContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostFThreadReaction([FromBody] CreateFThreadReactionDto dto)
    {
        FThreadReaction fThreadReaction = _mapper.Map<FThreadReaction>(dto);
        _context.Add(fThreadReaction);
        _context.SaveChanges();
        return Created("FThread Reaction Created", fThreadReaction);
    }

    [HttpGet]
    public IEnumerable<ReadFThreadReactionDto> GetFThreadReactions([FromQuery] int? fThreadId, [FromQuery] int take = 50)
    {
        if (fThreadId == null)
        {
            return _mapper.Map<List<ReadFThreadReactionDto>>(_context.FThreadReaction.Take(take).ToList());
        }
        else
        {
            return _mapper.Map<List<ReadFThreadReactionDto>>(_context.FThreadReaction.Take(take).
                                                        Where(fthreadReaction => fthreadReaction.ThreadId == fThreadId).ToList());
        }
    }

    [HttpGet("{fthreadId}/{userId}")]
    public ReadFThreadReactionDto GetFThreadReaction(int fthreadId, string UserId)
    {
        return _mapper.Map<ReadFThreadReactionDto>(_context.FThreadReaction.FirstOrDefault(fthreadReaction => fthreadReaction.ThreadId == fthreadId & fthreadReaction.UserId == UserId));
    }

    [HttpPut("{fthreadId}/{userId}")]
    public IActionResult PutFThreadReaction([FromQuery] int fThreadId, [FromQuery] string UserId, [FromBody] UpdateFThreadDto dto)
    {
        var fthreadReaction = _context.FThreadReaction.FirstOrDefault(fthreadReaction => fthreadReaction.ThreadId == fThreadId & fthreadReaction.UserId == UserId);
        if (fthreadReaction == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, fthreadReaction);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{fthreadId}/{userId}")]
    public IActionResult DeleteFThread(int fthreadId, string UserId)
    {
        var fthreadReaction = _context.FThreadReaction.FirstOrDefault(fthreadReaction => fthreadReaction.ThreadId == fthreadId & fthreadReaction.UserId == UserId);
        if (fthreadReaction == null)
        {
            return NotFound();
        }
        _context.Remove(fthreadReaction);
        _context.SaveChanges();
        return NoContent();
    }
}
