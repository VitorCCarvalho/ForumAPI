using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Post Id is required.")]
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
    [Required(ErrorMessage = "Text is required.")]
    [Range(3, 50, ErrorMessage = "Text need to have between 3 and 50 characters.")]
    public string Text { get; set; }
    public string UserId { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;

}
