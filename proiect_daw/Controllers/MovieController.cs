using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect_daw.Entities.DTOs;
using proiect_daw.Repositories.MovieRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _repository;
        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _repository.GetAllMoviesWithDirector();

            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                moviesToReturn.Add(new MovieDTO(movie));
            }

            return Ok(moviesToReturn);
        }
        /*
                [HttpGet("{name}")]
                public async Task<IActionResult> GetMovieById(int id)
                {
                    var movie = await _repository.GetById(id);

                    return Ok(new MovieDTO(movie));
                }*/

        /*  [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteMovie(int id)
          {
              var movie = await _repository.GetByIdAsync(id);

              if (movie == null)
              {
                  return NotFound("Movie does not exist!");
              }

              _repository.Delete(movie);

              await _repository.SaveAsync();

              return NoContent();
          }*/

        /*[HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDTO dto)
        {
            Movie newMovie = new Movie();

            newMovie.Id = dto.Id;
            newMovie.Name = dto.Name;
            newMovie.Year = dto.Year;
            newMovie.Genre = dto.Genre;

            _repository.Create(newMovie);

            await _repository.SaveAsync();


            return Ok(new MovieDTO(newMovie));
        }*/

    }
}
