using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem.Application.DTO
{
    public class RoleIndexDTO
    {
        public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();

        // Iska naam "Role" hona chahiye taake View ke "Role.RoleName" se match kare
        public RoleRequestDTO Role { get; set; } = new RoleRequestDTO();

    }

}
