﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
