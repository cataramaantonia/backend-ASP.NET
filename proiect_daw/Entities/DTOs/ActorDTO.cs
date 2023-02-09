using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Entities.DTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<MovieActor> MovieActors { get; set; }

        public ActorDTO(Actor actor)
        {
            this.Id = actor.Id;
            this.Name = actor.Name;
            this.Age = actor.Age;
            this.MovieActors = new List<MovieActor>();
        }
    }
}
