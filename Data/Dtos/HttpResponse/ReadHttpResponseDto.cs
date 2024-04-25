using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Dtos.UserToken;

public class ReadHttpResponseDto
{
    [Key]
    public string response { get; set; }
}
