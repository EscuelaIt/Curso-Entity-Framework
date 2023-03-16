using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BlogContext : DbContext {
    public DbSet<Blog> Blogs {get; set;}

    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        var added = ChangeTracker.Entries<Blog>()
        .Where(e => e.State == EntityState.Added)
        .Select(e => e.Entity).ToList();
        var retval = base.SaveChanges();
        foreach (var blog in added) {
            BlogEvents.Instance.OnBlogAdded(blog);
        }
        
        return retval;
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