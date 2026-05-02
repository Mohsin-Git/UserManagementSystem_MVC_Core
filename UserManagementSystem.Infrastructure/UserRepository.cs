using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Infrastructure
{
    public class UserRepository : IUserRepository
	{
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(UserManager<ApplicationUser> userManager) { _userManager = userManager; }

        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetUserByFullNameAsync(string fullName)
        {
            return _userManager.Users.FirstOrDefault(u => u.FullName == fullName);
        }
    }
}
