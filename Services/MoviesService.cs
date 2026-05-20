using swift_movies_blazor;
using System.Net.Http.Json;
using swift_movies_blazor.DTOs;

namespace swift_movies_blazor.Services;

public class MoviesService
{
    private readonly HttpClient _httpClient;

    public MoviesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        var movies = await _httpClient.GetFromJsonAsync<List<Movie>>("http://localhost:5000/api/movie");
        return movies ?? new List<Movie>();
    }

    public async Task<HttpResponseMessage> AddMovieAsync(NewMovieDTO newMovie)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/movie", newMovie);
        return response;
    }

    public async Task<HttpResponseMessage> UpdateMovieAsync(Movie movie)
    {
        var response = await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/movie/{movie.Id}", movie);
        return response;
    }

    public async Task<HttpResponseMessage> DeleteMovieAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5000/api/movie/{id}");
        return response;
    }
}