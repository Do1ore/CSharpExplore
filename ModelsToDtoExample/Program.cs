using ModelsToDtoExample;
using ModelsToDtoExample.Entities;


IEnumerable<PostDto> MapToDto(IEnumerable<Post> posts, IEnumerable<Comment> comments, IEnumerable<User> users)
{
    var postDtos = from post in posts
        join user in users on post.UserId equals user.Id into postUsers
        from postUser in postUsers.DefaultIfEmpty()
        join comment in comments on post.Id equals comment.PostId into postComments
        select new PostDto
        {
            PostContent = post.Content,
            UserName = postUser?.UserName,
            CommentsCount = postComments.Count()
        };
    return postDtos;
}

IEnumerable<PostDto> MapToDtoWithLinqExtensions(IEnumerable<Post> posts, IEnumerable<Comment> comments,
    IEnumerable<User> users)
{
    var postDtos = posts.GroupJoin(users,
            post => post.UserId,
            user => user.Id,
            (post, postUsers) => new { post, postUsers = postUsers.DefaultIfEmpty() })
        .SelectMany(x => x.postUsers,
            (x, postUser) => new { x.post, postUser })
        .GroupJoin(comments,
            x => x.post.Id,
            comment => comment.PostId,
            (x, postComments) => new PostDto
            {
                PostContent = x.post.Content,
                UserName = x.postUser?.UserName,
                CommentsCount = postComments.Count()
            });
    return postDtos;
}

List<User> users = new List<User>();
for (int i = 1; i <= 7; i++)
{
    users.Add(new User { Id = i.ToString(), UserName = $"User{i}" });
}

List<Post> posts = new List<Post>();
for (int i = 1; i <= 10; i++)
{
    posts.Add(new Post { Id = i.ToString(), Content = $"PostContent{i}", UserId = (i % 7 + 1).ToString() });
}

List<Comment> comments = new List<Comment>();
for (int i = 1; i <= 5; i++)
{
    comments.Add(new Comment { Id = i.ToString(), PostId = (i % 10 + 1).ToString() });
}


var result = MapToDtoWithLinqExtensions(posts, comments, users);
foreach (var dto in result)
{
    Console.WriteLine(dto);
}