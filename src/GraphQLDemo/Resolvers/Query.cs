using Data;
namespace GraphQLDemo.Resolvers;
public class Query
{

    private IMovieHandler _movieHandler;

    public Query(IMovieHandler movieHandler)
    {
        _movieHandler = movieHandler;
    }
    public async Task<IEnumerable<Movie>> GetMovies() => await _movieHandler.GetAllMoviesAsync();
    public async Task<Movie> GetMovieById(int id) => await _movieHandler.GetMovieById(id);
    public List<Actor> GetActors() => Seed.SeedActors();
    public List<Actor> GetActorByFirstName(string firstName) => Seed.SeedActors()
            .Where(x => x.FirstName.Equals(firstName, StringComparison.InvariantCultureIgnoreCase)).ToList();


    }


public interface IMovieHandler
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<Movie> GetMovieById(int id);
}

public class MovieHandler: IMovieHandler
{
    private IEnumerable<Movie> _movies;

    public MovieHandler()
    {
        _movies = Seed.SeedData();
    }
    
    public async Task<IEnumerable<Movie>> GetAllMoviesAsync() =>  await Task.FromResult(_movies);

    public async Task<Movie> GetMovieById(int id) => await Task.FromResult(_movies.FirstOrDefault(x => x.Id == id));

}
