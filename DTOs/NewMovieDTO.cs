using System.ComponentModel.DataAnnotations;

namespace swift_movies_blazor.DTOs
{
    public class NewMovieDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = default!;
        [Range(1888,2999, ErrorMessage = "Please enter a valid year between 1888 and 2999.")]
        public int Year { get; set; }
    }
}