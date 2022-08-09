Console.WriteLine("Running GraphQL.ClientDemo");
GraphqlClientBase.ITransferService _transferService = new GraphqlClientBase.TransferService();
Console.WriteLine("Getting Movie Information.....");
var movieDetails = await _transferService.GetMovies();
foreach (var movie in movieDetails.Movies)
{
    Console.WriteLine($"{movie.Title}");
    Console.WriteLine("Actors");
    movie.Actors.ForEach(x=>Console.WriteLine($"\t{x.FirstName} {x.LastName}"));
}
