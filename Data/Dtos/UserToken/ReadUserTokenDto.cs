using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Dtos.UserToken;

public class ReadUserTokenDto
{
    [Key]
    public string token { get; set; }
}
