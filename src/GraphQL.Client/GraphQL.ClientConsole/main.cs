Console.WriteLine("Running GraphQL.ClientDemo");
GraphqlClientBase.ITransferService _transferService = new GraphqlClientBase.TransferService();
Console.WriteLine("Getting Movie Information.....");
var movieDetails = await _transferService.GetMovies();

movieDetails.Movies.ForEach(x=>PrintMovie(x));

Console.WriteLine();
Console.WriteLine("Searching for movie id == 2");
SearchForMovieById(movieDetails, 2);

Console.WriteLine(new String('-', 80));
Console.WriteLine("Now calling Movies and actors, should return all movies and actors");
Console.WriteLine();
Console.WriteLine();

var details = await  _transferService.GetMovieAndActors();
PrintAllMoviesAndAllActors(details);


void PrintMovie(Movie movie)
{
    Console.WriteLine($"{movie.Title}");
    Console.WriteLine("Actors");
    movie.Actors.ForEach(x => Console.WriteLine($"\t{x.FirstName} {x.LastName}"));
}
void SearchForMovieById(GraphqlClientBase.MovieDetails movieDetails2, int moveIdToSearchFor)
{
    var selectedMovie = movieDetails2.Movies.Find(x => x.Id == moveIdToSearchFor);
    if (selectedMovie != null)
    {
        PrintMovie(selectedMovie);
    }
    else
    {
        Console.WriteLine("Movie Does Not Exist");
    }
}
void PrintAllMoviesAndAllActors(GraphqlClientBase.MovieAndActorsResponse movieAndActorsResponse)
{
    Console.WriteLine("------- Movies------");
    movieAndActorsResponse.Movies.ToList().ForEach(x=>PrintMovie(x));
    Console.WriteLine("------- Actors------");
    foreach (var currentActor in movieAndActorsResponse.Actors)
    {
        Console.WriteLine($"{currentActor.FirstName} {currentActor.LastName}");
    }
}