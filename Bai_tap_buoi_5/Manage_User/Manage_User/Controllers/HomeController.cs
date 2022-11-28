using Manage_User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Manage_User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Class1 oai = new Class1();

        //public Class1 Oai { get => oai; set => oai = value; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(oai.LayDS());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(DbUser n)
        {
            oai.Them(n);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(oai.Lays(id));
        }
        [HttpPost]
        public ActionResult Edit( DbUser n)
        {
            oai.Sua(n);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            oai.Xoa(id);
            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}