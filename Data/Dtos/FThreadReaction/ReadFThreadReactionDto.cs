using System.ComponentModel.DataAnnotations;
using ForumApp.Data.Dtos.FThread;
using ForumApp.Data.Dtos.User;

namespace ForumApp.Data.Dtos.FThreadReaction;

public class ReadFThreadReactionDto
{
    [Key]
    [Required(ErrorMessage = "Name is required.")]
    public int ThreadId { get; set; }
    [Key]
    [Required(ErrorMessage = "UserId is required.")]
    public string UserId { get; set; }
    [Required(ErrorMessage = "Reaction is required.")]
    public bool Reaction { get; set; }

    public virtual ReadFThreadDto FThread { get; set; }
    public virtual ReadUserDto User { get; set; }
}
