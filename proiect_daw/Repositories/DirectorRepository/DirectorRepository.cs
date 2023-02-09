using Microsoft.EntityFrameworkCore;
using proiect_daw.Data;
using proiect_daw.Entities;
using proiect_daw.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories.DirectorRepository
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(ProiectContext context) : base(context) { }

        public async Task<Director> GetByName(string name)
        {
            return await _context.Directors.Where(d => d.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<Director>> GetAllDirectors()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director> GetById(int id)
        {
            return await _context.Directors.Where(d => d.Id == id).FirstOrDefaultAsync();
        }
       
    }
}
