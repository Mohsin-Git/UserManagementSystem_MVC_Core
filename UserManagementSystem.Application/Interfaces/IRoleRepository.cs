using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
        Task<IdentityRole> GetRoleByIdAsync(string id);
        Task<bool> DeleteRoleAsync(string id);
        Task<bool> UpdateRoleAsync(IdentityRole role);

    }
}
