using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem.Application.DTO
{
	public class RoleRequestDTO
	{
        public string? Id { get; set; }
        [Required(ErrorMessage = "Role name is required")]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Role name must be between 3 and 20 characters")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed in role name")]
		[Display(Name = "Role Name")]
		public string RoleName { get; set; } = string.Empty;
	}
}
