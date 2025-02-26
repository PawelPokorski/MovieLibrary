using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieLibrary.Data.Context;

namespace MovieLibrary.Data;

public static class Extensions
{
    public static IServiceCollection AddDataConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MovieContext>(ctx =>
            ctx.UseSqlServer(configuration.GetConnectionString("MoviesLibrary")));

        return services;
    }
}