using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect_daw.Entities;
using proiect_daw.Entities.DTOs;
using proiect_daw.Repositories.DirectorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _repository;

        public DirectorController(IDirectorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDirectors()
        {
            var directors = await _repository.GetAllDirectors();

            var directorsToReturn = new List<DirectorDTO>();

            foreach (var director in directors)
            {
                directorsToReturn.Add(new DirectorDTO(director));
            }

            return Ok(directorsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDirectorById(int id)
        {
            var director = await _repository.GetById(id);

            return Ok(new DirectorDTO(director));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector(CreateDirectorDTO dto)
        {
            Director newdirector = new Director();
            newdirector.Name = dto.Name;
            newdirector.Age = dto.Age;

            _repository.Create(newdirector);

            await _repository.SaveAsync();

            return Ok(new DirectorDTO(newdirector));
        }

        [HttpPut("{id}+{age}")]
        public async Task<IActionResult> UpdateAge(int id, int age)
        {
            var newdirector = await _repository.GetById(id);
            newdirector.Age = age;

            _repository.Update(newdirector);
            await _repository.SaveAsync();
            return Ok(new DirectorDTO(newdirector));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var director = await _repository.GetById(id);
            if (director == null)
            {
                return NotFound("Director does not exist!");
            }
            _repository.Delete(director);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
