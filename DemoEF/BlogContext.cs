using Microsoft.EntityFrameworkCore;

public class BlogContext : DbContext 
{
    public DbSet<Blog> Blogs {get; set;}

    public DbSet<BlogPost> Posts {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres;Password=example");
    }
}