using Microsoft.EntityFrameworkCore.Infrastructure;

public class Blog {

    private List<BlogPost> _posts= new();
    public int Id {get; set;}

    public string Url {get; set;}

    public IEnumerable<BlogPost> Posts => _posts;

    public void Publish(BlogPost post) {
        _posts.Add(post);
        post.Blog = this;
    }
}

public class BlogPost {
    public int Id {get; set;}

    public Blog Blog {get; internal set;}
    public string Content {get; set;}
}


