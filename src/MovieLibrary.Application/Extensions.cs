using Microsoft.Extensions.DependencyInjection;
using MovieLibrary.Application.Enums;
using MovieLibrary.Core.Models;
using System.Reflection;

namespace MovieLibrary.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(executingAssembly));
        services.AddAutoMapper(executingAssembly);

        return services;
    }

    public static IEnumerable<Movie> Sort(this IEnumerable<Movie> movies, MovieSortOption sortOption)
    {
        return sortOption switch
        {
            MovieSortOption.TitleAscending => movies.OrderBy(m => m.Title),
            MovieSortOption.TitleDescending => movies.OrderByDescending(m => m.Title),
            MovieSortOption.AverageRatingAscending => movies.OrderBy(m => m.AverageRating),
            MovieSortOption.AverageRatingDescending => movies.OrderByDescending(m => m.AverageRating),
            MovieSortOption.RatingCountAscending => movies.OrderBy(m => m.MovieRatings.Count()),
            MovieSortOption.RatingCountDescending => movies.OrderByDescending(m => m.MovieRatings.Count()),
            _ => movies.OrderBy(m => m.Title),
        };
    }
}
