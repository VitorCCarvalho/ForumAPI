using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForumApp.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Thread Id is required.")] 
    public int ThreadId { get; set; }

    public virtual FThread Thread { get; set; }
    [Required(ErrorMessage = "Text is required.")]
    [Range(3, 50, ErrorMessage = "Text need to have between 3 and 50 characters.")]
    public string Text { get; set; }
    [Required(ErrorMessage = "User Id is required.")] 
    public string UserId { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool Locked { get; set; }
}
