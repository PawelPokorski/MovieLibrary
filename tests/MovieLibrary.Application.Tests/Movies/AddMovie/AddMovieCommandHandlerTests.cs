using AutoMapper;
using Moq;
using MovieLibrary.Application.Configuration.Mappings;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Application.Movies.Commands.AddMovie;
using MovieLibrary.Application.Movies.Queries.GetMovieById;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;


namespace MovieLibrary.Application.Tests.Movies.AddMovie;

public class AddMovieCommandHandlerTests
{
    private readonly Mock<IMovieRepository> _movieRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    
    public AddMovieCommandHandlerTests()
    {
        _movieRepositoryMock = new Mock<IMovieRepository>();
        _mapper = MapperHelper.CreateMapper(new MovieMappingProfile());
        _unitOfWorkMock = new Mock<IUnitOfWork>();
    }

    [Fact]
    public async Task Handle_ShouldAddMovie_WhenCommandIsValid()
    {
        // Arrange
        var command = new AddMovieCommand
        {
            Title = "Test Movie",
            Year = 2023,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Action" }
        };

        var handler = new AddMovieCommandHandler(_movieRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _movieRepositoryMock.Verify(repo => repo.Add(It.IsAny<Movie>()), Times.Once);
        _unitOfWorkMock.Verify(unit => unit.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Equal(command.Title, result.Title);
        Assert.Equal(command.Year, result.Year);
        Assert.Equal(command.Genre.Name, result.Genre);
        Assert.Equal(0.0m, result.AverageRating);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMovieIsAdded()
    {
        // Arrange
        var command = new AddMovieCommand
        {
            Title = "Test Movie",
            Year = 2023,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Action" }
        };

        var handler = new AddMovieCommandHandler(_movieRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkMock.Verify(unit => unit.SaveChangesAsync(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldAddMovieWithNullGenre_WhenGenreIsNull()
    {
        // Arrange
        var command = new AddMovieCommand
        {
            Title = "Test Movie",
            Year = 2023,
            Genre = null
        };

        var handler = new AddMovieCommandHandler(_movieRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _movieRepositoryMock.Verify(repo => repo.Add(It.IsAny<Movie>()), Times.Once);
        _unitOfWorkMock.Verify(unit => unit.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Null(result.Genre);
    }

    [Fact]
    public async Task Handle_ShouldMapMovieToMovieDtoCorrectly()
    {
        // Arrange
        var command = new AddMovieCommand
        {
            Title = "Test Movie",
            Year = 2023,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Action" }
        };

        var handler = new AddMovieCommandHandler(_movieRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(command.Title, result.Title);
        Assert.Equal(command.Year, result.Year);
        Assert.Equal(command.Genre.Name, result.Genre);
        Assert.Equal(0.0m, result.AverageRating);
    }

    [Fact]
    public async Task Handle_ShouldAddTwoMoviesWithDifferentGuids()
    {
        // Arrange
        var command1 = new AddMovieCommand
        {
            Title = "Movie 1",
            Year = 2023,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Action" }
        };

        var command2 = new AddMovieCommand
        {
            Title = "Movie 2",
            Year = 2024,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Comedy" }
        };

        var handler = new AddMovieCommandHandler(_movieRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        // Act
        var result1 = await handler.Handle(command1, CancellationToken.None);
        var result2 = await handler.Handle(command2, CancellationToken.None);

        // Assert
        Assert.NotEqual(result1.Id, result2.Id);
    }

    [Fact]
    public async Task Handle_ShouldReturnMovieDtoWithNonNullId_WhenMovieIsAdded()
    {
        // Arrange
        var command = new AddMovieCommand
        {
            Title = "Test Movie",
            Year = 2023,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Action" }
        };

        var handler = new AddMovieCommandHandler(_movieRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotEqual(Guid.Empty, result.Id);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenTitleIsMissing()
    {
        // Arrange
        var command = new AddMovieCommand
        {
            Title = null,
            Year = 2023,
            Genre = new Genre { Id = Guid.NewGuid(), Name = "Action" }
        };

        var handler = new AddMovieCommandHandler(_movieRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(command, CancellationToken.None));
    }
}