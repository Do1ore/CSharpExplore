using ModelsToDtoExample.Entities;

namespace ModelsToDtoExample;

public record PostDto
{
    public string PostContent { get; set; } 
    public string? UserName { get; set; }
    public int CommentsCount { get; set; }
}