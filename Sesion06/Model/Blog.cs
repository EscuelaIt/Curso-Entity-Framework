public class Blog {
    public int Id {get; set;}

    public string Url {get; set;}

    public IEnumerable<BlogPost> Posts {get; }

    public Blog()
    {
        Posts = new List<BlogPost>();
    }
}

public class RssBlog : Blog {
    public string RssUrl {get; set;}
    public int RssCount {get; set;}

}

public class OtherBlogType : Blog {
    public string Author {get; set;}
    public string RssUrl {get; set;}
}

public class BlogPost {
    public int Id {get; set;}
    // public int BlogId {get; set;}
    // public Blog Blog {get; set;}
    public string Content {get; set;}

}