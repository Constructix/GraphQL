using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc.Formatters;

public abstract class GraphqlClientBase
{
    public readonly GraphQLHttpClient _graphQLHttpClient ;
    
    public GraphqlClientBase()
    {
        if(_graphQLHttpClient == null)
        {
            _graphQLHttpClient = GetGraphQlApiClient();
        }
    }

    public GraphQLHttpClient GetGraphQlApiClient()
    {
        //initialize graphql endpoint eg:https://testproject1.hasura.app/v1/graphql
        var endpoint = "http://localhost:5266/graphQL";

        var httpClientOption = new GraphQLHttpClientOptions
        {
            EndPoint = new Uri(endpoint)
        };
        return new GraphQLHttpClient(httpClientOption, new NewtonsoftJsonSerializer());
    }
    
    
    public interface ITransferService
    {
        Task<MovieDetails> GetMovies();
        Task<MovieAndActorsResponse> GetMovieAndActors();
    }
    
    public class TransferService : GraphqlClientBase, ITransferService
    {
        public async Task<MovieDetails> GetMovies()
        {
            var query = @"query MyQuery { movies { id, title, actors { firstName, lastName} }}";

            var request = new GraphQLHttpRequest(query);

            var response = await _graphQLHttpClient.SendQueryAsync<MovieDetails>(request);

            return response.Data;

        }

        public async Task<MovieAndActorsResponse> GetMovieAndActors()
        {
            var query = @"query MyQuery { movies { 
                                                    id, 
                                                    title, 
                                                    actors { 
                                                                firstName, 
                                                                lastName } 
                                                 }, 
                                            actors { 
                                                    firstName, 
                                                    lastName
                                            }
                                          }";

            var request = new GraphQLHttpRequest(query);

            var response = await _graphQLHttpClient.SendQueryAsync<MovieAndActorsResponse>(request);

            return response.Data;
        }
    }

    public class MovieDetails
    {
        public List<Movie> Movies { get; set; }
    }

    public class MovieAndActorsResponse
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}