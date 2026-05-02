using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Application.IServices;
using UserManagementSystem.Domain.Entities;
using static UserManagementSystem.Application.DTO.AuthDTO;

namespace UserManagementSystem.Application.ServiceImplementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(IUserRepository userRepository, SignInManager<ApplicationUser> signInManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegistrationDTO model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName };
            return await _userRepository.RegisterUserAsync(user, model.Password);
        }

        public async Task<bool> LoginAsync(LoginDTO model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            if (user == null)
            {
                user = await _userRepository.GetUserByFullNameAsync(model.Email);
            }
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
                return result.Succeeded;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

      

    }
}
