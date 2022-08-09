//SeedData.cs
namespace Data
{
    public class Seed
    {


        public static List<Actor> SeedActors()
        {
            var actors = new List<Actor>
            {
                new Actor() { FirstName = "Mike", LastName = "Listo" },
                new Actor() { FirstName = "Bill", LastName = "D'Elia" },
                new Actor() { FirstName = "Robert", LastName = "Yannetti" },
                new Actor() { FirstName = "Steve", LastName = "Robin" },
                new Actor() { FirstName = "James", LastName = "R. Bagdonas" },
                new Actor() { FirstName = "Jeff", LastName = "Bleckner" },
            };
            return actors;
        }
        
        
        public static List<Movie> SeedData()
        {
            var actors = new List<Actor>
                {
                    new Actor
                    {
                        FirstName = "Bob",
                        LastName = "Kante"
                    },
                    new Actor
                    {
                        FirstName = "Mary",
                        LastName = "Poppins"
                    }
                };

            var movies = new List<Movie>
            {
                new Movie
                {
                 Id = 1,
                 Title = "The Rise of the GraphQL Warrior",
                 Actors = actors
                },
                new Movie
                {
                 Id = 2,
                 Title = "The Rise of the GraphQL Warrior Part 2",
                 Actors = actors
                }
            };
            return movies;
        }
    }
}