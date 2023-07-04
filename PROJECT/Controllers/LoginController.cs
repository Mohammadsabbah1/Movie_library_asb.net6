using Microsoft.AspNetCore.Mvc;
using PROJECT.Models;
using System.Linq;

namespace PROJECT.Controllers
{
    public class LoginController : Controller
    {
        private UserContext context { get; set; }

        public LoginController(UserContext ctx) => context = ctx;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User1 u)
        {
            List<User1> users = context.users.ToList();
            foreach(User1 a in users)
            {
                if (u.Email.Equals(a.Email)&&u.Email !=null)
                {
                    if (u.Password.Equals(a.Password)&&u.Password != null)
                    {
                        if (u.Email.Equals("mohammadsabbah990@gmail.com"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        HttpContext.Session.SetInt32("UserId", a.Id);
                        return RedirectToAction("Index", "Main");       
                    }
                }
            }
            Response.WriteAsync("<script>alert('Please enter corecte data')</script>");

            return View("Index");
        }


    }
}
