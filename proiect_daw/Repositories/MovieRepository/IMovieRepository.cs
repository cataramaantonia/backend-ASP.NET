using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.MovieRepository
{
    interface IMovieRepository
    {
        Task<Movie> GetByName(string name);
        Task<List<Movie>> GetByYear(int year);
        Task<List<Movie>> GetByGenre(string genre);
        Task<List<Movie>> GetAllMoviesWithDirector();
        Task<List<Movie>> GetAllMoviesWithActor();
    }
}
