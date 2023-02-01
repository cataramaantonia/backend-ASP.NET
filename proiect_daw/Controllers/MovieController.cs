using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        /*private readonly IMovieRepository _repository;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _repository.GetByIdWithAddress(id);

            return Ok(new AuthorDTO(author));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _repository.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound("Author does not exist!");
            }

            _repository.Delete(author);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDTO dto)
        {
            Author newAuthor = new Author();

            newAuthor.Name = dto.Name;
            newAuthor.Address = dto.Address;

            _repository.Create(newAuthor);

            await _repository.SaveAsync();


            return Ok(new AuthorDTO(newAuthor));
        }*/

    }
}
