using ForumApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ForumApp.Data;

public class ForumContext : IdentityDbContext<User>
{
    public ForumContext(DbContextOptions<ForumContext> opts) : base(opts) { }

    public DbSet<Forum> Forums { get; set; }
    public DbSet<FThread> Threads { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        

        builder.Entity<Post>()
                   .HasOne(post => post.Thread)
                   .WithMany(fthread => fthread.Posts)
                   .HasForeignKey(post => post.ThreadId);

        builder.Entity<FThread>()
                   .HasOne(fthread => fthread.Forum)
                   .WithMany(forum => forum.Threads)
                   .HasForeignKey(fthread => fthread.ForumID);

        base.OnModelCreating(builder);
    }
}
