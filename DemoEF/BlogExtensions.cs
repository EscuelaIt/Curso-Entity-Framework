static class BlogExtensions {

    public static bool HasPosts(this Blog blog) {
        return blog.Posts.Count() > 0;
    }
}