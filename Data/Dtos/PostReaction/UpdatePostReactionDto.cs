﻿using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Dtos.PostReaction;

public class UpdatePostReactionDto
{
    [Key]
    [Required(ErrorMessage = "Name is required.")]
    public int PostId { get; set; }
    [Required(ErrorMessage = "UserId is required.")]
    public string UserId { get; set; }
    [Required(ErrorMessage = "Reaction is required.")]
    public bool Reaction { get; set; }
}
