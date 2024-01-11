using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForumApp.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    [Required] public int ThreadId { get; set; }
    [Required] public string Text { get; set; }
    [Required] public string UserId { get; set; }
    public DateOnly DateCreated { get; set; }
    public bool Locked { get; set; }
}
