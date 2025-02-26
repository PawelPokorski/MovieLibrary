using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Infrastructure.Repositories;

namespace MovieLibrary.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IMovieRatingRepository, MovieRatingRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();

        return services;
    }
}