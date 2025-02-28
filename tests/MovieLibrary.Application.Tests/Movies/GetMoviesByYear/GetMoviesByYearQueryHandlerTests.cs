using AutoMapper;
using Moq;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Application.Enums;
using MovieLibrary.Application.Movies.Queries.GetMoviesByYear;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Tests.Movies.GetMoviesByYear;

public class GetMoviesByYearQueryHandlerTests
{
    private readonly Mock<IMovieRepository> _movieRepositoryMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    [Fact]
    public async Task GetMoviesByYearQueryHandler_ShouldReturnMovieDtos_WhenMoviesExist()
    {
        // Arrange
        var year = 2023;
        var movies = new List<Movie>
        {
            new Movie { Title = "Movie A", Year = 2023 },
            new Movie { Title = "Movie B", Year = 2023 },
            new Movie { Title = "Movie C", Year = 2023 }
        };
        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Movie A", Year = 2023 },
            new MovieDto { Title = "Movie B", Year = 2023 },
            new MovieDto { Title = "Movie C", Year = 2023 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByYearAsync(year, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByYearQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByYearQuery(year);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByYearQueryHandler_ShouldReturnEmptyList_WhenMoviesDoNotExist()
    {
        // Arrange
        var year = 2023;

        _movieRepositoryMock.Setup(repo => repo.GetByYearAsync(year, CancellationToken.None))
            .ReturnsAsync(new List<Movie>());
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(new List<MovieDto>());

        var handler = new GetMoviesByYearQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByYearQuery(year);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetMoviesByYearQueryHandler_ShouldReturnMovieDtosSortedByTitleAscending()
    {
        // Arrange
        var year = 2023;
        var movies = new List<Movie>
        {
            new Movie { Title = "Movie C", Year = 2023 },
            new Movie { Title = "Movie A", Year = 2023 },
            new Movie { Title = "Movie B", Year = 2023 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Movie A", Year = 2023 },
            new MovieDto { Title = "Movie B", Year = 2023 },
            new MovieDto { Title = "Movie C", Year = 2023 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByYearAsync(year, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByYearQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByYearQuery(year, MovieSortOption.TitleAscending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByYearQueryHandler_ShouldReturnMovieDtosSortedByTitleDescending()
    {
        // Arrange
        var year = 2023;
        var movies = new List<Movie>
        {
            new Movie { Title = "Movie C", Year = 2023 },
            new Movie { Title = "Movie A", Year = 2023 },
            new Movie { Title = "Movie B", Year = 2023 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Movie C", Year = 2023 },
            new MovieDto { Title = "Movie B", Year = 2023 },
            new MovieDto { Title = "Movie A", Year = 2023 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByYearAsync(year, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByYearQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByYearQuery(year, MovieSortOption.TitleDescending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByYearQueryHandler_ShouldReturnMovieDtosSortedByAverageRatingAscending()
    {
        // Arrange
        var year = 2023;
        var movies = new List<Movie>
        {
            new Movie { Title = "Movie C", Year = 2023, AverageRating = 3 },
            new Movie { Title = "Movie A", Year = 2023, AverageRating = 5 },
            new Movie { Title = "Movie B", Year = 2023, AverageRating = 4 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Movie C", Year = 2023 },
            new MovieDto { Title = "Movie B", Year = 2023 },
            new MovieDto { Title = "Movie A", Year = 2023 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByYearAsync(year, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByYearQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByYearQuery(year, MovieSortOption.AverageRatingAscending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByYearQueryHandler_ShouldReturnMovieDtosSortedByAverageRatingDescending()
    {
        // Arrange
        var year = 2023;
        var movies = new List<Movie>
        {
            new Movie { Title = "Movie C", Year = 2023, AverageRating = 3 },
            new Movie { Title = "Movie A", Year = 2023, AverageRating = 5 },
            new Movie { Title = "Movie B", Year = 2023, AverageRating = 4 }
        };
        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Movie A", Year = 2023 },
            new MovieDto { Title = "Movie B", Year = 2023 },
            new MovieDto { Title = "Movie C", Year = 2023 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByYearAsync(year, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByYearQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByYearQuery(year, MovieSortOption.AverageRatingDescending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }
}