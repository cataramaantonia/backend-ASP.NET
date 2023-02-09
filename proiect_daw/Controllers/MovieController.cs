using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect_daw.Entities;
using proiect_daw.Entities.DTOs;
using proiect_daw.Repositories;
using proiect_daw.Repositories.DirectorRepository;
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
        private readonly IDirectorRepository _directors;
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
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _repository.GetById(id);

            return Ok(new MovieDTO(movie));
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetMovieByName(string name)
        {
            var movie = await _repository.GetByName(name);

            return Ok(new MovieDTO(movie));
        }


        [HttpGet("join")]
        public async Task<IActionResult> GetAllMoviesWithDirectorNames()
        {
            var movies = await _repository.GetAllMoviesWithDirector();
            var directors = await _directors.GetAllDirectors();

            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                moviesToReturn.Add(new MovieDTO(movie));
            }


            var result = movies.Join(directors,
                movie => movie.DirectorId,
                director => director.Id,
                (movie, director) => new
                {
                    movieName = movie.Name,
                    directorName = director.Name
                });

            return Ok(result);
        }

        [HttpGet("groupby")]
        public async Task<IActionResult> GetAllMoviesGroupedByDirector()
        {
            var movies = await _repository.GetAllMovies();

            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                moviesToReturn.Add(new MovieDTO(movie));
            }

            var results = moviesToReturn.GroupBy(
                r => r.DirectorId,
                r => r.Name,
                (key, d) => new { DirectorIds = key, Names = d.ToList() });

            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDTO dto)
        {
            Movie newmovie = new Movie();
            newmovie.Name = dto.Name;
            newmovie.Director = dto.Director;
            newmovie.Duration = dto.Duration;
            newmovie.Year = dto.Year;
            newmovie.Genre = dto.Genre;
            newmovie.Review = dto.Review;
            newmovie.Budget = dto.Budget;

            _repository.Create(newmovie);

            await _repository.SaveAsync();

            return Ok(new MovieDTO(newmovie));
        }

        [HttpPut("{id}+{review}")]
        public async Task<IActionResult> UpdateReview(int id, float review)
        {
            var newmovie = await _repository.GetById(id);
            newmovie.Review = (newmovie.Review + review) / 2;

            _repository.Update(newmovie);
            await _repository.SaveAsync();
            return Ok(new MovieDTO(newmovie));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _repository.GetById(id);
            if (movie == null)
            {
                return NotFound("Movie does not exist!");
            }
            _repository.Delete(movie);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
