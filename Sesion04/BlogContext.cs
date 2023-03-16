using Microsoft.EntityFrameworkCore;

public class BlogContext : DbContext 
{
    public DbSet<Blog> Blogs {get; set;}

    public DbSet<BlogPost> Posts {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres;Password=example");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasKey(b => b.Id);
        modelBuilder.Entity<BlogPost>().
            HasOne(p => p.OwnerBlog).
            WithMany(b => b.Posts);

        modelBuilder.Entity<BlogPost>().
            HasMany(p => p.Tags).
            WithMany(t => t.Posts).
            UsingEntity(k => k.ToTable("postsandblogs"));
    
    }
}