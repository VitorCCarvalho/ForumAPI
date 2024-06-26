﻿using AutoMapper;
using ForumApp.Data;
using ForumApp.Data.Dtos.Forum;
using ForumApp.Data.Dtos.FThread;
using ForumApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;

[ApiController]
[Route("[controller]")]
public class FThreadController : ControllerBase
{
    private ForumContext _context;
    private IMapper _mapper;

    public FThreadController(ForumContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria uma thread nova.
    /// </summary>
    [HttpPost]
    public IActionResult PostFThread([FromBody] CreateFThreadDto dto)
    {
        FThread fthread = _mapper.Map<FThread>(dto);
        _context.Add(fthread);
        _context.SaveChanges();
        return Created("Thread created", fthread);
    }

    /// <summary>
    /// Retorna todas as threads.
    /// </summary>
    [HttpGet]
    public IEnumerable<ReadFThreadDto> GetFThreads([FromQuery] int? forumId, [FromQuery] int take = 50)
    {
        if (forumId == null)
        {
            return _mapper.Map<List<ReadFThreadDto>>(_context.Threads.Take(take).ToList());
        }
        else
        {
            return _mapper.Map<List<ReadFThreadDto>>(_context.Threads.Take(take).
                                                        Where(fthread => fthread.ForumID == forumId).ToList());
        }
    }

    /// <summary>
    /// Retorna a thread que possui fthreadId como ID.
    /// </summary>
    [HttpGet("{fthreadId}")]
    public ReadFThreadDto GetFThreadById(int fthreadId)
    {
        return _mapper.Map<ReadFThreadDto>(_context.Threads.FirstOrDefault(fthread => fthread.Id == fthreadId));
    }

    /// <summary>
    /// Atualiza a thread que possui fthreadId como ID.
    /// </summary>
    [HttpPut("{fthreadId}")]
    public IActionResult PutFThread(int fthreadId, [FromBody] UpdateFThreadDto dto)
    {
        var fthread = _context.Threads.FirstOrDefault(fthread => fthread.Id == fthreadId);
        if (fthread == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, fthread);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza uma parte da thread que possui fthreadId como ID.
    /// </summary>
    [HttpPatch("{fthreadId}")]
    public IActionResult PatchFThread(int fthreadId, JsonPatchDocument<UpdateFThreadDto> patch)
    {
        var fthread = _context.Threads.FirstOrDefault(fthread => fthread.Id == fthreadId);
        if (fthread == null)
        {
            return NotFound();
        }
        var fthreadPatch = _mapper.Map<UpdateFThreadDto>(fthread);
        patch.ApplyTo(fthreadPatch, ModelState);

        if (!TryValidateModel(fthreadPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(fthreadPatch, fthread);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta a thread que possui fthreadId como ID.
    /// </summary>
    [HttpDelete("{fthreadId}")]
    public IActionResult DeleteFThread(int fthreadId)
    {
        var fthread = _context.Threads.FirstOrDefault(fthread => fthread.Id == fthreadId);
        if (fthread == null)
        {
            return NotFound();
        }
        _context.Remove(fthread);
        _context.SaveChanges();
        return NoContent();
    }
}
