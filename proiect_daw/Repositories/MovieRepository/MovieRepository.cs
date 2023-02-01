﻿using Microsoft.EntityFrameworkCore;
using proiect_daw.Data;
using proiect_daw.Entities;
using proiect_daw.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.MovieRepository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ProiectContext context) : base(context) { }

        public async Task<Movie> GetByName(string name)
        {
            return await _context.Movies.Where(m => m.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<Movie>> GetByYear(int year)
        {
            return await _context.Movies.Where(m => m.Year == year).ToListAsync();
        }

        public async Task<List<Movie>> GetByGenre(string genre)
        {
            return await _context.Movies.Where(m => m.Genre.Equals(genre)).ToListAsync();
        }

        public async Task<List<Movie>> GetAllMoviesWithDirector()
        {
            return await _context.Movies.Include(m => m.Director).ToListAsync();
        }
        
        public async Task<List<Movie>> GetAllMoviesWithActor()
        {
            return await _context.Movies.Include(m => m.MovieActors).ToListAsync();
        }
    }
}