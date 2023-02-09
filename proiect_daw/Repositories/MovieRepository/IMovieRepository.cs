using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.MovieRepository
{
     public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<Movie> GetByName(string name);
        Task<List<Movie>> GetAllMoviesWithDirector();
        Task<Movie> GetById(int id);
        Task<List<Movie>> GetAllMovies();
    }
}
