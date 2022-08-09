Console.WriteLine("Running GraphQL.ClientDemo");
GraphqlClientBase.ITransferService _transferService = new GraphqlClientBase.TransferService();
Console.WriteLine("Getting Movie Information.....");
var movieDetails = await _transferService.GetMovies();
PrintMovies(movieDetails);
Console.WriteLine();
Console.WriteLine("Now calling Movies and actors, should return all movies and actors");

var details = await  _transferService.GetMovieAndActors();

foreach (var currentActor in details.Actors)
{
    Console.WriteLine($"{currentActor.FirstName} {currentActor.LastName}");
}


void PrintMovies(GraphqlClientBase.MovieDetails movieDetails1)
{
    foreach (var movie in movieDetails1.Movies)
    {
        Console.WriteLine($"{movie.Title}");
        Console.WriteLine("Actors");
        movie.Actors.ForEach(x => Console.WriteLine($"\t{x.FirstName} {x.LastName}"));
    }
}

SearchForMovieById(movieDetails);

void SearchForMovieById(GraphqlClientBase.MovieDetails movieDetails2)
{
    var movieIdExists = movieDetails2.Movies.Find(x => x.Id == 2);

    Console.WriteLine(movieIdExists != null ? "Movie Exists......." : "Movie Does not exist.....");
}