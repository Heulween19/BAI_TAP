using System.ComponentModel.DataAnnotations;
using Xamarin.Essentials;
using Manage_User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Manage_User.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Moi nhap email!")]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Moi nhap password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
