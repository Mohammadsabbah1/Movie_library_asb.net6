using Microsoft.AspNetCore.Mvc;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class SignupController : Controller
    {
        private UserContext context { get; set; }

        public SignupController (UserContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User1 y)
        {
            
           
            if (y.PasswordConfirmed==y.Password &&y.Email != null && y.Password !=null) { 
          
                context.users.Add(y);
                context.SaveChanges();
                return RedirectToAction("Index", "Login");

            }
            Response.WriteAsync("<script>alert('Please enter corecte data')</script>");
            return View();
        }
    }
}
