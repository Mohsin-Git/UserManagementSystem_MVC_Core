using Microsoft.AspNetCore.Identity;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Application.IServices;

namespace UserManagementSystem.Infrastructure.ServiceImplementation;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<string>> GetRoleNamesAsync()
    {
        var roles = await _roleRepository.GetAllRolesAsync();
        return roles.Select(r => r.Name).ToList()!;
    }

    public async Task<bool> CreateNewRoleAsync(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName)) return false;
        if (await _roleRepository.RoleExistsAsync(roleName)) return false;

        return await _roleRepository.CreateRoleAsync(roleName.Trim());
    }

    
    public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
    {
        return await _roleRepository.GetAllRolesAsync();
    }
    public async Task<IdentityRole> GetRoleByIdAsync(string id)
    {
        return await _roleRepository.GetRoleByIdAsync(id);
    }

    public async Task<bool> UpdateRoleAsync(IdentityRole role)
    {
        // 1. Validation
        if (role == null || string.IsNullOrWhiteSpace(role.Id) || string.IsNullOrWhiteSpace(role.Name))
            return false;

        // 2. Database se asli role dhoondein taake tracking bani rahe
        var existingRole = await _roleRepository.GetRoleByIdAsync(role.Id);
        if (existingRole == null) return false;

        // 3. Purane object ki properties ko update karein
        existingRole.Name = role.Name;
        existingRole.NormalizedName = role.Name.ToUpper(); //

        // 4. Ab tracked object ko repository ke zariye update karein
        return await _roleRepository.UpdateRoleAsync(existingRole);
    }
    public async Task<bool> DeleteRoleAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) return false;

        return await _roleRepository.DeleteRoleAsync(id);
    }
}