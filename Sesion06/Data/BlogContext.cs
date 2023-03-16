using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BlogContext : DbContext {
    public DbSet<Blog> Blogs {get; set;}
    public DbSet<RssBlog> RssBlogs {get; set;}
    
    public DbSet<OtherBlogType> OtherBlog {get; set;}

    public DbSet<TPTBlog> TptBlogs {get; set;}
    public DbSet<TPTRssBlog> TPTRssBlogs {get; set;}

    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        foreach (var entry in this.ChangeTracker.Entries()) 
        {
            // Console.WriteLine($"Entry: {entry.Entity.GetType().Name} --> {entry.State}");
            if (entry.State == EntityState.Modified  || entry.State == EntityState.Added) {
                if (entry.Entity is Blog) {
                    entry.Property("LastUpdated").CurrentValue = DateTime.UtcNow;
                }
            }
        }
        return base.SaveChanges();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasKey(b => b.Id);
        // Configuración Shadow Properties
        modelBuilder.Entity<Blog>().Property<DateTime>("LastUpdated");

        // TPH: Compartir columna
        modelBuilder.Entity<RssBlog>().Property(b => b.RssUrl)
            .HasColumnName("RssUrl");
        modelBuilder.Entity<OtherBlogType>().Property(b => b.RssUrl)
            .HasColumnName("RssUrl");

        // TPT: Configuración
        modelBuilder.Entity<TPTBlog>().ToTable("TPTBlogs");
        modelBuilder.Entity<TPTRssBlog>().ToTable("TPTRssBlogs");


    }
}

public class BlogContextDesignFactory : IDesignTimeDbContextFactory<BlogContext>
{
    public BlogContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
        optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres;Password=example");
        return new BlogContext(optionsBuilder.Options);
    }
}