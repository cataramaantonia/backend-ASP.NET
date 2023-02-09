using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Entities.DTOs
{
    public class CreateMovieDTO
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public float Review { get; set; }
        public Budget Budget { get; set; }
    }
}
