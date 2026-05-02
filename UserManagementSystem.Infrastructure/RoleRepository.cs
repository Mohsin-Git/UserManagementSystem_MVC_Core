using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Application.Interfaces;

namespace UserManagementSystem.Infrastructure
{
    public class RoleRepository: IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync() =>
        await _roleManager.Roles.ToListAsync();

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            return result.Succeeded;
        }

        public async Task<bool> RoleExistsAsync(string roleName) =>
            await _roleManager.RoleExistsAsync(roleName);

        public async Task<IdentityRole> GetRoleByIdAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<bool> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return false;

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> UpdateRoleAsync(IdentityRole role)
        {
            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
    }
}
