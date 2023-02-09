using proiect_daw.Data;
using proiect_daw.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(ProiectContext context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }

}
