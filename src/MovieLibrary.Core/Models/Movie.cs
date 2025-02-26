using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLibrary.Core.Models;

public class Movie : Entity
{
    public string Title { get; set; }
    public short Year { get; set; }
    public decimal AverageRating { get; set; }

    public Guid? GenreId { get; set; }
    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }

    public IEnumerable<MovieRating> MovieRatings { get; set; }
    
    // public IEnumerable<Actor> Actors { get; set; }
    // public Director Director { get; set; }
    // public Image Image { get; set; }
}