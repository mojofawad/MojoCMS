namespace MojoCMS.API.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public Blog Blog { get; set; }
    public int BlogId { get; set; }
    public List<Tag> Tags { get; set; }
}