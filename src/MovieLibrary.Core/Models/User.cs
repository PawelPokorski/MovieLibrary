namespace MovieLibrary.Core.Models;

public class User : Entity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public IEnumerable<MovieRating> MovieRatings { get; set; }
}