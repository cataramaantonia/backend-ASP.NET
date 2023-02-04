using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.MovieRepository
{
     public interface IMovieRepository
    {
        Task<Movie> GetById(int id);
        Task<List<Movie>> GetAllMoviesWithDirector();
        Task<List<Movie>> GetAllMoviesWithActor();
    }
}
