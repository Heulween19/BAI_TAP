using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using MngUser.Common;
//using RoleUserApp.Dto;
using MngUser.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MngUser.Common;

namespace MngUser.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Index1()
        {
            return View();
        }

        // GET: Users
        //[Authorize(Policy = "Create user")]
        public async Task<IActionResult> Index()
        {
            string s = HttpContext.Session.GetString(Session.USERNAME);
            TempData[Session.USERNAME] = s;
            ViewBag.name = s;
            var roleUserAppContext = _context.LstUsers.Include(u => u.Group);
            return View(await roleUserAppContext.ToListAsync());
        }
    }
}
