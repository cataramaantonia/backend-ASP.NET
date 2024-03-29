﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Entities.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public float Review { get; set; }
        public Budget Budget { get; set; }

        public MovieDTO(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Duration = movie.Duration;
            this.Year = movie.Year;
            this.Genre = movie.Genre;
            this.DirectorId = movie.DirectorId;
            this.Director = new Director();
            this.Review = movie.Review;
            this.Budget = new Budget();
        }
    }
}
