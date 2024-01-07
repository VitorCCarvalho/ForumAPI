using ForumApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data;

public class ForumContext : IdentityDbContext<User>
{
    public ForumContext(DbContextOptions<ForumContext> opts) : base(opts) { }
}
