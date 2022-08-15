public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Actor> Actors { get; set; } = Enumerable.Empty<Actor>().ToList();
}