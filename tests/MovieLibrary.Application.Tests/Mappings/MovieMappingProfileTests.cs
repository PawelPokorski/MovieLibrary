using AutoMapper;
using MovieLibrary.Application.Configuration.Mappings;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Tests.Mappings;

public class MovieMappingProfileTests
{
    private readonly IMapper _mapper;

    public MovieMappingProfileTests()
    {
        _mapper = MapperHelper.CreateMapper(new MovieMappingProfile());
    }

    [Fact]
    public void MovieToMovieDto_ShouldMapCorrectly()
    {
        // Arrange
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = "Test Movie",
            Year = 2023,
            AverageRating = 8.5m,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Action" },
            MovieRatings = new List<MovieRating>
            {
                new MovieRating { MovieId = Guid.NewGuid(), Rate = 9 },
                new MovieRating { MovieId = Guid.NewGuid(), Rate = 8 }
            }
        };

        // Act
        var movieDto = _mapper.Map<MovieDto>(movie);

        // Assert
        Assert.Equal(movie.Id, movieDto.Id);
        Assert.Equal(movie.Title, movieDto.Title);
        Assert.Equal(movie.Year, movieDto.Year);
        Assert.Equal(movie.AverageRating, movieDto.AverageRating);
        Assert.Equal(movie.Genre.Name, movieDto.Genre);
        Assert.Equal(movie.MovieRatings.Count(), movieDto.MovieRatings.Count());
    }

    [Fact]
    public void MovieToMovieDto_ShouldMapNullGenreCorrectly()
    {
        // Arrange
        var movie = new Movie
        {
            Title = "Test Movie",
            Year = 2023,
            AverageRating = 8.5m,
            Genre = null,
            MovieRatings = []
        };

        // Act
        var movieDto = _mapper.Map<MovieDto>(movie);

        // Assert
        Assert.Null(movieDto.Genre);
    }

    [Fact]
    public void MovieToMovieDto_ShouldMapEmptyMovieRatingsCorrectly()
    {
        // Arrange
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = "Test Movie",
            Year = 2023,
            AverageRating = 8.5m,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Action" },
            MovieRatings = new List<MovieRating>()
        };

        // Act
        var movieDto = _mapper.Map<MovieDto>(movie);

        // Assert
        Assert.Empty(movieDto.MovieRatings);
    }
}