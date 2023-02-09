using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Entities.DTOs
{
    public class DirectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Movie> Movies { get; set; }

        public DirectorDTO(Director director)
        {
            this.Id = director.Id;
            this.Name = director.Name;
            this.Age = director.Age;
            this.Movies = new List<Movie>();
        }
    }
}
