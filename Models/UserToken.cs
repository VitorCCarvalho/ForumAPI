using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models;

public class UserToken
{
    [Key]
    public string token { get; set; }
}
