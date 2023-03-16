public class TPTBlog {
    public int Id {get; set;}

    public string Url {get; set;}

    public IEnumerable<BlogPost> Posts {get; }

    public TPTBlog()
    {
        Posts = new List<BlogPost>();
    }
}

public class TPTRssBlog : TPTBlog {
    public string RssUrl {get; set;}
    public int RssCount {get; set;}

}