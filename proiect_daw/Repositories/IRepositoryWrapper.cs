using proiect_daw.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        Task SaveAsync();
    }
}
