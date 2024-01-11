using ForumApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data;

public class ForumContext : IdentityDbContext<User>
{
    public ForumContext(DbContextOptions<ForumContext> opts) : base(opts) { }

    public DbSet<Forum> Forums { get; set; }
    public DbSet<FThread> Threads { get; set; }
    public DbSet<Post> Posts { get; set; }
}
