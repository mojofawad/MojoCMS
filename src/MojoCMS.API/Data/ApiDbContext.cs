using Microsoft.EntityFrameworkCore;
using MojoCMS.API.Models;

namespace MojoCMS.API.Data;

// TODO: Add Migrations
// TODO: Move to MigrationsService
public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    DbSet<Blog> Blogs { get; set; }
    DbSet<Post> Posts { get; set; }
    DbSet<Tag> Tag { get; set; }
}