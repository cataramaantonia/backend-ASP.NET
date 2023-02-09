using proiect_daw.Entities;
using proiect_daw.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetByIdWithRoles(int id);
    }
}
