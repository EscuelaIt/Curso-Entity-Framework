using Microsoft.AspNetCore.Mvc;

namespace Sesion03.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogsController : ControllerBase
{

    private readonly BlogContext _db;
    public BlogsController(BlogContext ctx)
    {
        _db = ctx;
    }
   
    [HttpGet]
    public IEnumerable<Blog> Get()
    {
        return _db.Blogs;
    }

    [HttpPost("{id}/name")]
    public void ChangeName(int id, string name) 
    {
        var blog  = _db.Blogs.Find(id);
        if (blog is not null) {
            blog.Name = name;
            _db.SaveChanges();
        }

    }

    [HttpPost("{id}/name2")]
    public void ChangeNameDisconnected(int id, string name) 
    {
        var blog = new Blog() {Id = id};
        var entry = _db.Add(blog);
        entry.State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;    
        blog.Name = name;
        var rows = _db.SaveChanges();
        
    }
}
