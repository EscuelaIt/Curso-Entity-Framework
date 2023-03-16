using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Blog {
    private List<BlogPost> _posts;
    public string Name {get;set;}


    [Key]
    public int Id {get; set;}

    [NotMapped]
    public DateTime LoadedAt {get; set;} = DateTime.UtcNow;

    public string Url {get; set;}

    public IEnumerable<BlogPost> Posts => _posts;

    public void Publish(BlogPost post) {
        _posts.Add(post);
    }


    public Blog()
    {
        _posts =new List<BlogPost>();
    }
    
}

public class BlogPost {
    public int Id {get; set;}

    public Blog Blog {get; set;} 
    public string Author {get; set;} = "";
    public string Text {get; set;}
}