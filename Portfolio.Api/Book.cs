using Portfolio.RepositoryPattern;

namespace Portfolio.Api;

public class Book : IEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }
}

public class MongoBook : IEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public MongoBook(string id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }
}