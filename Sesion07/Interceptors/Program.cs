using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres;Password=example");

var ctx =  new BlogContext(optionsBuilder.Options);
var blogs = ctx.Blogs.TagWith("patata").ToList();

ctx.Blogs.Where(b => b.Id < 10).ToList();