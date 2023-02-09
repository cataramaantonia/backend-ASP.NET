using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.ActorRepository
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        Task<Actor> GetByName(string name);
        Task<List<Actor>> GetAllActors();
        Task<Actor> GetById(int id);
    }
}
