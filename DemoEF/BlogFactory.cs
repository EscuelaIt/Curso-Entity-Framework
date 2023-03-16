static class BlogFactory{

    public static Blog CreateNew()  {
        var  num = new Random().Next(1, 10000);
        var posts_num = new Random().Next(1, 3);
        var blog =  new Blog() {
            Name = $"Random Blog # {num}",
            Url = $"http://some-blog.com/{num}",
        };

        foreach (var post in CreateBlogPosts(posts_num)) {
            blog.Publish(post);
        }

        return blog;

    }

    public static IEnumerable<BlogPost> CreateBlogPosts(int count) {
        var  num = new Random().Next(1, 10000);
        for (int i=0; i< count; i++) {
            yield return new BlogPost() {
                Author = $"Author {num}",
                Text = "Lorem ipsum......"
            };
        }
    }

}