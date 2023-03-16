using Microsoft.EntityFrameworkCore;

public class BlogContext : DbContext 
{
    public DbSet<Blog> Blogs {get; set;}

    public DbSet<BlogPost> Posts {get; set;}

    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres;Password=example");
    }
}