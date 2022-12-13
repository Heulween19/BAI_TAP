using Microsoft.AspNetCore.Mvc;
using Manage_User.Models;
using IdentityModel.OidcClient;
using Manage_User.Constant;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Manage_User.Controllers
{
    public class LoginController1 : Controller
    {
        
        
        
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(DbUser user )
        {
            if(ModelState.IsValid)
            {
                using (DbUserContext db = new DbUserContext())
                {
                    db.DbUsers.Add(user);
                    db.SaveChanges();
                }    
                ModelState.Clear();
                ViewBag.Message = "Successful Registered";
            } 
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost,ActionName("Login")]
        public ActionResult Login(DbUser user,Session session )
        {
            using (var db = new DbUserContext())
            {
                var usr = db.DbUsers.Single(u=>u.UserName == user.UserName&& u.Password==user.Password);
                if (usr != null)
                {
                    //Session.USERID = usr.Id.ToString();
                    //Session["UserName"] = usr.UserName.ToString();
                    HttpContext.Session.SetString(Session.USERID,user.UserName);
                    return RedirectToAction("Index");
                }
                else
                { ModelState.AddModelError("", "Username or Password is wrong"); }
                
            }
            return View();
        }
        //[HttpPost,ActionName("Login")]
        //public ActionResult Login(string username, string password)
        //{
        //    string s = HttpContext.Session.GetString(Session.USERID);
        //    ViewBag.name = s;
        //    if (s != null)
        //    {
        //        return View();
        //    }    
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }    
        //}
    }
}
