using Microsoft.EntityFrameworkCore;


var builder = new DbContextOptionsBuilder<BlogContext>();
builder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres;Password=example");
var options = builder.Options;
var ctx = new BlogContext(options);

ctx.Database.Migrate();

/*
var blog = new TPTBlog() {
    Url = "http://demo.blog"
};

var rssBlog = new TPTRssBlog() {
    RssCount = 25,
    RssUrl = "http://rss.xml",
    Url = "http://demo2.blog"
};

ctx.TptBlogs.Add(blog);
ctx.TPTRssBlogs.Add(rssBlog);

ctx.SaveChanges();
*/

var blogs = ctx.TPTRssBlogs.ToList();

foreach (var blog in blogs) {
    Console.WriteLine("URL: " + blog.Url);
}


/*
var blogs = ctx.Blogs.ToList();


var blog = new Blog() {
    Url = "http://demo.blog"
};


ctx.Blogs.Add(blog);

var rssBlog = new RssBlog() {
    Url="http://demo-rss.blog",
    RssUrl="http://demo-rss.xml"
};

ctx.RssBlogs.Add(rssBlog);


var otherBlog = new OtherBlogType() {
    Url="http://demo-rss.blog",
    RssUrl="http://demo-rss.xml",
    Author = "Super Yo"
};

ctx.OtherBlog.Add(otherBlog);

ctx.SaveChanges();


/*
var blog = new Blog() {
    Url = "http://demo.blog"
};

ctx.Blogs.Add(blog);
ctx.Entry(blog).Property("LastUpdated").CurrentValue = DateTime.Now;
ctx.SaveChanges();


var blog = ctx.Blogs.First();
var value = (DateTime)ctx.Entry(blog).Property("LastUpdated").CurrentValue;
Console.WriteLine(value);
*/