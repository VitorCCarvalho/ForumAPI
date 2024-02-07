namespace ForumApp.Data.Dtos.User;

using ForumApp.Models;
public class ReadUserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.Now;
    public virtual ICollection<FThread> Threads { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
}
