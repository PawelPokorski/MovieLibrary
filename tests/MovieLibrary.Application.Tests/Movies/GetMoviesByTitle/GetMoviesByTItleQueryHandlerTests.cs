using AutoMapper;
using Moq;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Application.Enums;
using MovieLibrary.Application.Movies.GetMoviesByTitle;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Tests.Movies.GetMoviesByTitle;

public class GetMoviesByTItleQueryHandlerTests
{
    private readonly Mock<IMovieRepository> _movieRepositoryMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    [Fact]
    public async Task GetMoviesByTitleQueryHandler_ShouldReturnMovieDtos_WhenMoviesExist()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie> { new Movie { Title = "Test Movie 1" }, new Movie { Title = "Test Movie 2" } };
        var movieDtos = new List<MovieDto> { new MovieDto { Title = "Test Movie 1" }, new MovieDto { Title = "Test Movie 2" } };

        _movieRepositoryMock.Setup(repo => repo.GetByTitleAsync(title, CancellationToken.None)).ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(movies)).Returns(movieDtos);

        var handler = new GetMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByTitleQuery(title);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByTitleQueryHandler_ShouldReturnEmptyList_WhenMoviesDoNotExist()
    {
        // Arrange
        var title = "Test";

        _movieRepositoryMock.Setup(repo => repo.GetByTitleAsync(title, CancellationToken.None)).ReturnsAsync(new List<Movie>());

        var handler = new GetMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByTitleQuery(title);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }

    #region Sort Mode Tests

    [Fact]
    public async Task GetMoviesByTitleQueryHandler_ShouldReturnMovieDtosSortedByTitleAscending()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie>
        {
            new Movie { Title = "Test Movie C", AverageRating = 3 },
            new Movie { Title = "Test Movie A", AverageRating = 5 },
            new Movie { Title = "Test Movie B", AverageRating = 4 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Test Movie A", AverageRating = 5 },
            new MovieDto { Title = "Test Movie B", AverageRating = 4 },
            new MovieDto { Title = "Test Movie C", AverageRating = 3 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByTitleAsync(title, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByTitleQuery(title, MovieSortOption.TitleAscending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByTitleQueryHandler_ShouldReturnMovieDtosSortedByTitleDescending()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie>
        {
            new Movie { Title = "Test Movie C", AverageRating = 3 },
            new Movie { Title = "Test Movie A", AverageRating = 5 },
            new Movie { Title = "Test Movie B", AverageRating = 4 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Test Movie C", AverageRating = 3 },
            new MovieDto { Title = "Test Movie B", AverageRating = 4 },
            new MovieDto { Title = "Test Movie A", AverageRating = 5 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByTitleAsync(title, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByTitleQuery(title, MovieSortOption.TitleDescending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByTitleQueryHandler_ShouldReturnMovieDtosSortedByAverageRatingAscending()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie>
        {
            new Movie { Title = "Test Movie C", AverageRating = 3 },
            new Movie { Title = "Test Movie A", AverageRating = 5 },
            new Movie { Title = "Test Movie B", AverageRating = 4 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Test Movie C", AverageRating = 3 },
            new MovieDto { Title = "Test Movie B", AverageRating = 4 },
            new MovieDto { Title = "Test Movie A", AverageRating = 5 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByTitleAsync(title, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByTitleQuery(title, MovieSortOption.AverageRatingAscending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByTitleQueryHandler_ShouldReturnMovieDtosSortedByAverageRatingDescending()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie>
        {
            new Movie { Title = "Test Movie C", AverageRating = 3 },
            new Movie { Title = "Test Movie A", AverageRating = 5 },
            new Movie { Title = "Test Movie B", AverageRating = 4 }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Test Movie A", AverageRating = 5 },
            new MovieDto { Title = "Test Movie B", AverageRating = 4 },
            new MovieDto { Title = "Test Movie C", AverageRating = 3 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByTitleAsync(title, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByTitleQuery(title, MovieSortOption.AverageRatingDescending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByTitleQueryHandler_ShouldReturnMovieDtosSortedByRatingCountAscending()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie>
        {
            new Movie { Title = "Test Movie C", MovieRatings = new List<MovieRating> { new (), new (), new () } },
            new Movie { Title = "Test Movie A", MovieRatings = new List<MovieRating> { new (), new (), new (), new (), new () } },
            new Movie { Title = "Test Movie B", MovieRatings = new List<MovieRating> { new (), new (), new (), new () } }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Test Movie C", RatingCount = 3 },
            new MovieDto { Title = "Test Movie B", RatingCount = 4 },
            new MovieDto { Title = "Test Movie A", RatingCount = 5 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByTitleAsync(title, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByTitleQuery(title, MovieSortOption.RatingCountAscending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    [Fact]
    public async Task GetMoviesByTitleQueryHandler_ShouldReturnMovieDtosSortedByRatingCountDescending()
    {
        // Arrange
        var title = "Test";
        var movies = new List<Movie>
        {
            new Movie { Title = "Test Movie C", MovieRatings = new List<MovieRating> { new (), new (), new () } },
            new Movie { Title = "Test Movie A", MovieRatings = new List<MovieRating> { new (), new (), new (), new (), new () } },
            new Movie { Title = "Test Movie B", MovieRatings = new List<MovieRating> { new (), new (), new (), new () } }
        };

        var movieDtos = new List<MovieDto>
        {
            new MovieDto { Title = "Test Movie A", RatingCount = 5 },
            new MovieDto { Title = "Test Movie B", RatingCount = 4 },
            new MovieDto { Title = "Test Movie C", RatingCount = 3 }
        };

        _movieRepositoryMock.Setup(repo => repo.GetByTitleAsync(title, CancellationToken.None))
            .ReturnsAsync(movies);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<MovieDto>>(It.IsAny<IEnumerable<Movie>>()))
            .Returns(movieDtos);

        var handler = new GetMoviesByTitleQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMoviesByTitleQuery(title, MovieSortOption.RatingCountDescending);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDtos, result);
    }

    #endregion
}