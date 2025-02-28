using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Dtos;

public class MovieDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public short Year { get; set; }
    public string Genre { get; set; }
    public decimal AverageRating { get; set; }
    public IEnumerable<MovieRating> MovieRatings { get; set; } // change to MovieRatingDto collection
}