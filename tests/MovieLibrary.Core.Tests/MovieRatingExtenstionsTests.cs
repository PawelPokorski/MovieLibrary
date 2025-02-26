using MovieLibrary.Core.Extensions;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Tests;

public class MovieRatingExtensionsTests
{
    [Fact]
    public void GetAverageRating_WithValidRatings_ReturnsCorrectAverage()
    {
        // Arrange
        var ratings = new List<MovieRating>
        {
            new MovieRating { Rate = 5 },
            new MovieRating { Rate = 4 },
            new MovieRating { Rate = 3 }
        };

        // Act
        decimal averageRating = ratings.GetAverageRating();

        // Assert
        Assert.Equal(4, averageRating);
    }

    [Fact]
    public void GetAverageRating_WithEmptyRatings_ReturnsZero()
    {
        // Arrange
        var ratings = new List<MovieRating>();

        // Act
        decimal averageRating = ratings.GetAverageRating();

        // Assert
        Assert.Equal(0, averageRating);
    }

    [Fact]
    public void GetAverageRating_WithNullRatings_ReturnsZero()
    {
        // Arrange
        IEnumerable<MovieRating> ratings = [];

        // Act
        decimal averageRating = ratings.GetAverageRating();

        // Assert
        Assert.Equal(0, averageRating);
    }

    [Fact]
    public void GetAverageRating_WithSingleRating_ReturnsRating()
    {
        // Arrange
        var ratings = new List<MovieRating>
        {
            new MovieRating { Rate = 5 }
        };

        // Act
        decimal averageRating = ratings.GetAverageRating();

        // Assert
        Assert.Equal(5, averageRating);
    }

    [Fact]
    public void GetAverageRating_WithDecimalAverage_ReturnsCorrectAverage()
    {
        // Arrange
        var ratings = new List<MovieRating>
        {
            new MovieRating { Rate = 5 },
            new MovieRating { Rate = 4 },
            new MovieRating { Rate = 4 }
        };

        // Act
        decimal averageRating = ratings.GetAverageRating();

        // Assert
        Assert.Equal(4.333333333333333, (double)averageRating, 15);
    }
}