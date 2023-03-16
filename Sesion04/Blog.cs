using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Blog {
    public string Name {get;set;}


    public int Id {get; set;}

    public string Url {get; set;}


    [InverseProperty("OwnerBlog")]
    public ICollection<BlogPost> Posts {get; set;}


    public Blog(string url, string name)
    {
        Url = url;
        Name = name;
        Posts = new List<BlogPost>();
    }

    public BlogImage BlogImage {get; set;}
}


public class BlogImage {
    public int Id {get; set;}
    public string FileName {get; set;}

    public int BlogId {get; set;}
}

public class BlogPost {
    public int Id {get; set;}

    public Blog OwnerBlog {get; set;}
    public string Author {get; set;} = "";
    public string Text {get; set;}

    public ICollection<Tag> Tags {get; set;}
}

public class Tag 
{
    public int Id {get; set;}
    public string Text {get; set;}

    public ICollection<BlogPost> Posts {get; set;}
}