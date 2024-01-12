﻿using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Dtos.Forum;

public class CreateForumDto
{
    [Required] 
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
}
