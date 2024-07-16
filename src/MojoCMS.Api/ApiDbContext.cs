using Microsoft.EntityFrameworkCore;
using MojoCMS.Api.Models;

namespace MojoCMS.Api;

// TODO: Add Migrations
public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tag { get; set; }
}