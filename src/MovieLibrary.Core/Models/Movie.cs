using MovieLibrary.Core.Extensions;

namespace MovieLibrary.Core.Models;

public class Movie : Entity
{
    public string Title { get; set; }
    public short Year { get; set; }
    public decimal AverageRating { get; set; }

    public Guid GenreId { get; set; }
    public IEnumerable<MovieRating> MovieRatings { get; set; }
}

public class Test
{
    public void Przyklad()
    {
        var movie = new Movie
        {
            MovieRatings = new List<MovieRating>
            {
                new MovieRating { Rate = 5 },
                new MovieRating { Rate = 4 },
                new MovieRating { Rate = 3 }
            }
        };

        decimal averageRating = movie.MovieRatings.GetAverageRating();
        Console.WriteLine(averageRating); // Wyświetli 4
    }
}