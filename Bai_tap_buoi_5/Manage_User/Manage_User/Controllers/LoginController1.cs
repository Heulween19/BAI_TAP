using Microsoft.AspNetCore.Mvc;
using Manage_User.Models;
using IdentityModel.OidcClient;

namespace Manage_User.Controllers
{
    public class LoginController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginRequest request)
        {
            return View();
        }
        
    }
}
