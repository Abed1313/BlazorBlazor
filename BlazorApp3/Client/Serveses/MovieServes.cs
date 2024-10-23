using BlazorApp3.Shared;
using System.Net.Http.Json;

namespace BlazorApp3.Client.Serveses
{
    public class MovieServes
    {
        private readonly HttpClient _httpClient;

        public MovieServes(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetAllMovie()
        {
            return await _httpClient.GetFromJsonAsync<List<Movie>>("api/movie");
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Movie>($"api/movie/{id}");
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            var movie1 = await _httpClient.PostAsJsonAsync("api/movie", movie);

            return await movie1.Content.ReadFromJsonAsync<Movie>();
        }
    }
}
