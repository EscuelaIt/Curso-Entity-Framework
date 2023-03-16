using Microsoft.EntityFrameworkCore;

var ctx = new BlogContext();

/*

var blog = new Blog("http://blog.test", "Test") {
    // Posts = new List<BlogPost>()
};

var blogpost = new BlogPost() {
    Author = "Edu",
    Text = "Lorem ipsum"
};

blog.Posts.Add(blogpost);

ctx.Blogs.Add(blog);
ctx.SaveChanges();

*/
Console.WriteLine("Blog List");

var blogs = ctx.Blogs.Include(b => b.Posts).ThenInclude(p => p.Tags);


Console.WriteLine($"Blog count: {blogs.Count()}");

foreach (var blog in blogs) {
    Console.WriteLine($"Blog {blog.Id} has {blog.Posts.Count()} posts");
    foreach (var post in blog.Posts) {
        Console.WriteLine($"Post author: {post.Author}");
        foreach (var tag in post.Tags) {
            Console.WriteLine($"Tag: {tag}");
        }
    }
}

