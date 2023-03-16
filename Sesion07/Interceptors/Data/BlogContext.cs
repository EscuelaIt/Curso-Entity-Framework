using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BlogContext : DbContext {
    public DbSet<Blog> Blogs {get; set;}

    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.AddInterceptors(new TaggedQueryCommandInterceptor());
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