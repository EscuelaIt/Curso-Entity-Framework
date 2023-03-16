public delegate void BlogAddedEventHandler (Blog blog);

class BlogEvents {

    private static BlogEvents _instance = new();
    public static BlogEvents Instance => _instance;
    private BlogEvents()  {}
    public event BlogAddedEventHandler BlogAdded;

    internal void OnBlogAdded(Blog b) => BlogAdded?.Invoke(b);
}