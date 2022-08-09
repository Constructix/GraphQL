using Data;
namespace GraphQLDemo.Resolvers;
public class Query
    {
        public List<Movie> GetMovies() =>
            Seed.SeedData();

        public Movie GetMovieById(int id) =>
            Seed.SeedData().FirstOrDefault(x => x.Id == id);

        public List<Actor> GetActors() => Seed.SeedActors();

        public List<Actor> GetActorByFirstName(string firstName) => Seed.SeedActors()
            .Where(x => x.FirstName.Equals(firstName, StringComparison.InvariantCultureIgnoreCase)).ToList();


    }
