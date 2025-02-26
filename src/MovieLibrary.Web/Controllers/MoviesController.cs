using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Interfaces.Repositories;

namespace MovieLibrary.Web.Controllers;

[Route("api/movies")]
[ApiController]
public class MoviesController(IMovieRepository movieRepository) : Controller
{
    #region GET

    [HttpGet]
    public async Task<ViewResult> GetAllMovies(CancellationToken cancellation)
    {
        var movies = await movieRepository.GetAllAsync(cancellation);

        return View(movies);
    }

    #endregion

    #region POST

    #endregion

    #region PUT

    #endregion

    #region DELETE

    #endregion
}