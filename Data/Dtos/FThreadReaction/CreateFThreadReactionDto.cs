﻿using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Dtos.FThreadReaction;

public class CreateFThreadReactionDto
{
    [Key]
    [Required(ErrorMessage = "Name is required.")]
    public int ThreadId { get; set; }
    [Required(ErrorMessage = "UserId is required.")]
    public string UserId { get; set; }
    [Required(ErrorMessage = "Reaction is required.")]
    public bool Reaction { get; set; }
}
