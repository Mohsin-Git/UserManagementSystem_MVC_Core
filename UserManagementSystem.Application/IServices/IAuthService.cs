using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UserManagementSystem.Application.DTO.AuthDTO;

namespace UserManagementSystem.Application.IServices
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegistrationDTO model);
        Task<bool> LoginAsync(LoginDTO model);
        Task LogoutAsync();
    }
}
