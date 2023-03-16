using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres;Password=example");
optionsBuilder.LogTo(Console.WriteLine);
var ctx =  new BlogContext(optionsBuilder.Options);


if (!args.Any()) return;

var t =  args[0] switch {
    "--seed" => Seed(),
    "--standard" => Standard(),
    "--include" => Include(),
    "--lazy" => Lazy(),
    _ => Task.Run(() => Console.WriteLine("Invalid command"))
};

await t;


async Task Seed()
{
    for (var idx=0; idx < 10; idx++) {
        var blog = new Blog() {
            Url = $"http://blog_{idx}"
        };
        for (var pidx = 0; pidx <1000; pidx++) {
            var post = new BlogPost() {
                Content = $"Post #{pidx} for blog {idx}...."
            };
            blog.Publish(post);
        }
        ctx.Blogs.Add(blog);
    }
    await ctx.SaveChangesAsync();
    Console.WriteLine("Seed done");
}

async Task Standard() 
{
    var blogs = ctx.Blogs.Skip(2).Take(5);
    foreach (var blog in blogs) {
        Console.WriteLine($"Blog {blog.Id} --> {blog.Url} tiene {blog.Posts.Count()} posts");
    }
}


async Task Include() 
{
    var blogs = ctx.Blogs.Skip(2).Take(5);
    foreach (var blog in blogs.Include(p => p.Posts)) {
        Console.WriteLine($"Blog {blog.Id} --> {blog.Url} tiene {blog.Posts.Count()} posts");
    }
}

async Task Lazy()
{
    var blog = ctx.Blogs.Skip(2).First();
    foreach (var post in blog.Posts) {
        Console.WriteLine("BlogPost: " + post.Content);
    }

}