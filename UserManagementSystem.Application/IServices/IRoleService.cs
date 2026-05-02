using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem.Application.IServices
{
    public interface IRoleService
    {
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<IEnumerable<string>> GetRoleNamesAsync();
        Task<bool> CreateNewRoleAsync(string roleName);
        Task<IdentityRole> GetRoleByIdAsync(string id);
        Task<bool> DeleteRoleAsync(string id);
        Task<bool> UpdateRoleAsync(IdentityRole role);

    }
}
