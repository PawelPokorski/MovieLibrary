using AutoMapper;
using Moq;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Application.Movies.GetTopMoviesByTitle;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Tests.Movies.GetTopMoviesByTitle;

public class GetTopMoviesByTitleQueryHandlerTests
{
    private readonly Mock<IMovieRepository> _movieRepositoryMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    [Fact]
    public async Task GetTopMoviesByTitleQueryHandler_ShouldReturnTopMovieDtos_WhenMoviesExist()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie> { new Movie { Title = "Test Movie 1", AverageRating = 5 }, new Movie { Title = "Test Movie 2", AverageRating = 4 } };
        var movieDtos = new List<MovieDto> { new MovieDto { Title = "Test Movie 1", AverageRating = 5 }, new MovieDto { Title = "Test Movie 2", AverageRating = 4 } };

        _movieRepositoryMock.Setup(repo => repo.GetTopByTitleAsync(title, 2, CancellationToken.None)).ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(movies)).Returns(movieDtos);

        var handler = new GetTopMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetTopMoviesByTitleQuery(title, 2);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetTopMoviesByTitleQueryHandler_ShouldReturnLimitedMovieDtos()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie>
        {
            new Movie { Title = "Test Movie 1", AverageRating = 5 },
            new Movie { Title = "Test Movie 2", AverageRating = 4 },
            new Movie { Title = "Test Movie 3", AverageRating = 3 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Test Movie 1", AverageRating = 5 },
            new MovieDto { Title = "Test Movie 2", AverageRating = 4 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetTopByTitleAsync(title, 2, CancellationToken.None)).ReturnsAsync(movies.Take(2));
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(movies.Take(2))).Returns(movieDtos);

        var handler = new GetTopMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetTopMoviesByTitleQuery(title, 2);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetTopMoviesByTitleQueryHandler_ShouldReturnSortedMovieDtos()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie>
        {
            new Movie { Title = "Test Movie 1", AverageRating = 3 },
            new Movie { Title = "Test Movie 2", AverageRating = 5 },
            new Movie { Title = "Test Movie 3", AverageRating = 4 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Test Movie 2", AverageRating = 5 },
            new MovieDto { Title = "Test Movie 3", AverageRating = 4 },
            new MovieDto { Title = "Test Movie 1", AverageRating = 3 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetTopByTitleAsync(title, 3, CancellationToken.None))
            .ReturnsAsync(movies.OrderByDescending(m => m.AverageRating));

        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetTopMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetTopMoviesByTitleQuery(title, 3);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetTopMoviesByTitleQueryHandler_ShouldReturnEmptyList_WhenMoviesDoNotExist()
    {
        // Arrange
        var title = "Test";

        _movieRepositoryMock.Setup(repo => repo.GetTopByTitleAsync(title, 5, CancellationToken.None)).ReturnsAsync(new List<Movie>());

        var handler = new GetTopMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetTopMoviesByTitleQuery(title, 5);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }

}