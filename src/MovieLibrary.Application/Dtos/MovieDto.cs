namespace MovieLibrary.Application.Dtos;

public class MovieDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public short Year { get; set; }
    public string Genre { get; set; }
    public decimal AverageRating { get; set; }
    public int RatingCount { get; set; }

    // public string Director { get; set; }
    // public IEnumerable<Actor> Actors { get; set; }
}