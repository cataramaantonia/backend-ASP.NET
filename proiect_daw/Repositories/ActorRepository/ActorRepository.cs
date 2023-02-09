using Microsoft.EntityFrameworkCore;
using proiect_daw.Data;
using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.ActorRepository
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(ProiectContext context) : base(context) { }

        public async Task<Actor> GetByName(string name)
        {
            return await _context.Actors.Where(a => a.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Actor>> GetAllActors()
        {
        return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> GetById(int id)
        {
            return await _context.Actors.Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
