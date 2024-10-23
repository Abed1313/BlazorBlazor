using BlazorApp3.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _movieContext;

        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        [HttpGet]
        public IActionResult GetAllMovie()
        {
            var AllMovie = _movieContext.Select().Execute();

            return Ok(AllMovie);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieContext.Select().Where(s => s.Eq(r => r.MovieId,id)).Execute().FirstOrDefault();
            if(movie == null)
            {
                return NotFound("Not Found");
            }
            return Ok(movie);
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            var newMovie = _movieContext.Insert().WithFields(m => m.Exclude(s=>s.MovieId)).Execute(movie,returnNewRecord:true);

            return CreatedAtAction(nameof(GetAllMovie),new {Id = newMovie.MovieId},newMovie);
        }
    }
}
