﻿using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Dtos.Comment;

public class CreateCommentDto
{
    [Required(ErrorMessage = "Post Id is required.")]
    public int PostId { get; set; }
    [Required(ErrorMessage = "Text is required.")]
    [StringLength(50, ErrorMessage = "Text need to have between 3 and 50 characters.")]
    public string Text { get; set; }
    [Required(ErrorMessage = "User Id is required.")]
    public string UserId { get; set; }
}