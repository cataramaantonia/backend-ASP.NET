using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public Review Review { get; set; }
        public Budget Budget { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
