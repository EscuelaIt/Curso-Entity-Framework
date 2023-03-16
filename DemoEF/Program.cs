using Microsoft.EntityFrameworkCore;

var ctx = new BlogContext();

var blog = BlogFactory.CreateNew();
ctx.Blogs.Add(blog);
ctx.SaveChanges();

var id = blog.Id;

foreach (var dbBlog in ctx.Blogs) {
    Console.WriteLine(dbBlog.Name);
}

var readedBlog = ctx.Blogs.Find(id);


Console.WriteLine("readed: " + readedBlog.Name);








