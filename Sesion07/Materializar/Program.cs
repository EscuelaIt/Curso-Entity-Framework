using Microsoft.EntityFrameworkCore;

BlogEvents.Instance.BlogAdded += OnNewBlog;

var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres;Password=example");
var ctx =  new BlogContext(optionsBuilder.Options);

ctx.Blogs.Add(new Blog() {
    Url="newww"!
});

ctx.SaveChanges();

Console.ReadLine();




void OnNewBlog(Blog blog) {
    Console.WriteLine($"Se ha creado el blog {blog.Url}");
}