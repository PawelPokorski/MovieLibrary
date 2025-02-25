namespace MovieLibrary.Core.Models;

public class Movie : Entity
{
    public string Title { get; set; }
    public short Year { get; set; }
    public decimal AverageRating { get; set; }

    public Guid GenreId { get; set; }
    public IEnumerable<MovieRating> MovieRatings { get; set; }
}
