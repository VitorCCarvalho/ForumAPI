using ForumApp.Data.Dtos.FThread;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ForumApp.Data.Dtos.Forum;

public class ReadForumDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ReadFThreadDto> Threads { get; set; }

}
