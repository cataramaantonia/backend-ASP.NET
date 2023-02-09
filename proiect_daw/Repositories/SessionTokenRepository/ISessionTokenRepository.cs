using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories
{
    public interface ISessionTokenRepository : IGenericRepository<SessionToken>
    {
        Task<SessionToken> GetByJTI(string jti);
    }

}
