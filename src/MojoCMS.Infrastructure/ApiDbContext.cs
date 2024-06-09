using Microsoft.EntityFrameworkCore;
using MojoCMS.Domain.Models;

namespace MojoCMS.Infrastructure;

// TODO: Add Migrations
public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tag { get; set; }
}