using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.DirectorRepository
{
    public interface IDirectorRepository : IGenericRepository<Director>
    {
        Task<Director> GetByName(string name);
        Task<List<Director>> GetAllDirectors();
        Task<Director> GetById(int id);
    }
}
