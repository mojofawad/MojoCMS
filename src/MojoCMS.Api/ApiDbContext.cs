using Microsoft.EntityFrameworkCore;
using MojoCMS.Api.Models;

namespace MojoCMS.Api;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Tag> Tag => Set<Tag>();
}