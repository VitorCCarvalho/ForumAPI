﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models;

public class User: IdentityUser
{
    public User() : base() { }

    [Required(ErrorMessage = "Display name is required")]
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.Now;
    public virtual ICollection<FThread> Threads { get; set; }
    public virtual ICollection<Post> Posts { get; set; }

}
