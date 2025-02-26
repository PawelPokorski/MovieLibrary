using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Extensions;

public static class MovieRatingExtensions
{
    public static decimal GetAverageRating(this IEnumerable<MovieRating> ratings)
    {
        if (ratings == null || !ratings.Any())
        {
            return 0;
        }

        var ratingsAmount = ratings.Count();
        var ratingsSum = ratings.Sum(x => x.Rate);

        return (decimal)ratingsSum / ratingsAmount;
    }
}
