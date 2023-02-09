using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect_daw.Entities;
using proiect_daw.Entities.DTOs;
using proiect_daw.Repositories.ActorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _repository;

        public ActorController(IActorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _repository.GetAllActors();

            var actorsToReturn = new List<ActorDTO>();

            foreach (var actor in actors)
            {
                actorsToReturn.Add(new ActorDTO(actor));
            }

            return Ok(actorsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            var actor = await _repository.GetById(id);

            return Ok(new ActorDTO(actor));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor(CreateActorDTO dto)
        {
            Actor newactor = new Actor();
            newactor.Name = dto.Name;
            newactor.Age = dto.Age;

            _repository.Create(newactor);

            await _repository.SaveAsync();

            return Ok(new ActorDTO(newactor));
        }

        [HttpPut("{id}+{age}")]
        public async Task<IActionResult> UpdateAge(int id, int age)
        {
            var newactor = await _repository.GetById(id);
            newactor.Age = age;

            _repository.Update(newactor);
            await _repository.SaveAsync();
            return Ok(new ActorDTO(newactor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await _repository.GetById(id);
            if (actor == null)
            {
                return NotFound("Actor does not exist!");
            }
            _repository.Delete(actor);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
