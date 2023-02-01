using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.DirectorRepository
{
    interface IDirectorRepository
    {
        Task<Director> GetByName(string name);
        Task<List<Director>> GetByDebutInYear(int year);
    }
}
