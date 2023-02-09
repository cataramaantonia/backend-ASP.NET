using Microsoft.AspNetCore.Identity;
using proiect_daw.Constants;
using proiect_daw.Data;
using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Seeders
{
    public class RoleSeeder
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly ProiectContext _context;

        public RoleSeeder(RoleManager<Role> roleManager, ProiectContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public async Task SeedRoles()
        {
            if (_context.Roles.Any())
            {
                return;
            }

            string[] roleNames =
            {
                UserRoleType.Admin,
                UserRoleType.User
            };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    roleResult = await _roleManager.CreateAsync(new Role
                    {
                        Name = roleName
                    });
                }

                await _context.SaveChangesAsync();
            }
        }

    }
}
