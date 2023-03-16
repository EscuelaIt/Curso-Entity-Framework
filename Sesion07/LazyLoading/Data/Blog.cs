using Microsoft.EntityFrameworkCore.Infrastructure;

public class Blog {

    private readonly ILazyLoader? _loader;
    private ICollection<BlogPost> _posts;
    public int Id {get; set;}

    public string Url {get; set;}

    public ICollection<BlogPost> Posts {
        get {
            _loader.Load(this, ref _posts);
            return _posts;
        }
        set {
            _posts = value;
        }
    }

    public void Publish(BlogPost post) {
        _posts.Add(post);
        post.Blog = this;
    }

    public Blog() {}

    public Blog(ILazyLoader lazyLoader)
    {
        _loader = lazyLoader;
    }
}

public class BlogPost {
    public int Id {get; set;}

    public Blog Blog {get; internal set;}
    public string Content {get; set;}
}


