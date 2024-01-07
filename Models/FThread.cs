using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models;

public class FThread
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int ForumID { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    [Range(3, 50, ErrorMessage = "Name need to have between 3 and 50 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Text is required.")]
    [Range(3, 2000, ErrorMessage = "Text need to have between 3 and 2000 characters.")]
    public string Text { get; set; }
    public bool? Sticky { get; set; }
    public bool? Active { get; set; }
    public DateTime DateCreated { get; set; }
    public int StartedByUserId { get; set; }
    public bool? Locked { get; set; }
    public virtual ICollection<Post> Posts { get; set; }

}
