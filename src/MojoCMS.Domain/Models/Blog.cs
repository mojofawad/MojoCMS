namespace MojoCMS.Domain.Models;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public List<Post> Posts { get; set; }
}