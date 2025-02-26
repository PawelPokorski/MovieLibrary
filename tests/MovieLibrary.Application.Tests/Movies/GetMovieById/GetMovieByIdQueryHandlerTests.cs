using AutoMapper;
using Moq;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Application.Movies.GetMovieById;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Tests.Movies.GetMovieById;

public class GetMovieByIdQueryHandlerTests
{
    private readonly Mock<IMovieRepository> _movieRepositoryMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    [Fact]
    public async Task GetMovieByIdQueryHandler_ShouldReturnMovieDto_WhenMovieExists()
    {
        // Arrange
        var movieId = Guid.NewGuid();
        var movie = new Movie { Id = movieId, Title = "Test Movie" };
        var movieDto = new MovieDto { Id = movieId, Title = "Test Movie" };

        _movieRepositoryMock.Setup(repo => repo.GetByIdAsync(movieId, CancellationToken.None)).ReturnsAsync(movie);
        _mapperMock.Setup(mapper => mapper.Map<MovieDto>(movie)).Returns(movieDto);

        var handler = new GetMovieByIdQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMovieByIdQuery(movieId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(movieDto, result);
    }

    [Fact]
    public async Task GetMovieByIdQueryHandler_ShouldReturnNull_WhenMovieDoesNotExist()
    {
        // Arrange
        var movieId = Guid.NewGuid();

        _movieRepositoryMock.Setup(repo => repo.GetByIdAsync(movieId, CancellationToken.None)).ReturnsAsync((Movie)null);

        var handler = new GetMovieByIdQueryHandler(_movieRepositoryMock.Object, _mapperMock.Object);
        var query = new GetMovieByIdQuery(movieId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }

}