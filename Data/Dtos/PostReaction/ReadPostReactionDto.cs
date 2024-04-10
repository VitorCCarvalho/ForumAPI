﻿using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Dtos.PostReaction;

public class ReadPostReactionDto
{
    public int PostId { get; set; }
    public string UserId { get; set; }
    public bool Reaction { get; set; }
}
