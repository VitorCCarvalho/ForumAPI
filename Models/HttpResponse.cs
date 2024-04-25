using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models;

public class HttpResponse
{
    [Key]
    public string response { get; set; }
}
