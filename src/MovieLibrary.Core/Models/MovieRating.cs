namespace MovieLibrary.Core.Models;

public class MovieRating : Entity
{
    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    
    public int Rate { get; set; }
}