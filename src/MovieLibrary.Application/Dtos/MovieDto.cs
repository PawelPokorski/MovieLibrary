namespace MovieLibrary.Application.Dtos;

public class MovieDto
{
    public string Title { get; set; }
    public short Year { get; set; }
    public decimal AverageRating { get; set; } // MovieRatings

    public string Genre { get; set; } // Genres.GetById(Movie.GenreId).Name;
}