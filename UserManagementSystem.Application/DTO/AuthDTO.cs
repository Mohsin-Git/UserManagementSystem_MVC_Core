using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem.Application.DTO
{
    public class AuthDTO
    {
        public class RegistrationDTO
        {
            [Required(ErrorMessage = "FullName is required")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [DataType(DataType.EmailAddress)]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            public string? Email { get; set; }
            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
            public string? Password { get; set; }

            [Required(ErrorMessage = "Confirm Password is required")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords don't match.")]
            [Display(Name = "Confirm Password")]
            public string? ConfirmPassword { get; set; }

        }
        public class LoginDTO
        {
            [Required(ErrorMessage = "Username is required.")]
            [Display(Name = "Username / Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember Me")]
            public bool RememberMe { get; set; }
        }
    }
}
