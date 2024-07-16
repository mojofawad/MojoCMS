using System.ComponentModel.DataAnnotations;

namespace MojoCMS.Api.Models;

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

public class PostItem
{
    public int Id { get; set; }
    [Required] public string Title { get; set; }
    public string Content { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public int BlogId { get; set; }
}

public static class PostMappingExtensions
{
    public static PostItem AsPostItem(this Post post)
    {
        return new()
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            BlogId = post.BlogId
        };
    }
}