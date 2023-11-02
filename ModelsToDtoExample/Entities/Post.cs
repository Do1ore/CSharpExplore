using System.Globalization;

namespace ModelsToDtoExample.Entities;

public class Post
{
    public string Id { get; set; }
    public string Content { get; set; }
    public string UserId { get; set; }
}