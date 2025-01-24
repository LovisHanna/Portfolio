using Portfolio.RepositoryPattern.Shared;

namespace Portfolio.Api;

public class Book : IEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int ISBN { get; set; }
    public string Publisher { get; set; }
    public bool IsAvailable { get; set; }
    public string Genre { get; set; }
}