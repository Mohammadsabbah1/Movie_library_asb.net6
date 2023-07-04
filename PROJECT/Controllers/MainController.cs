using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Models;
using Microsoft.AspNetCore.Http;
namespace PROJECT.Controllers
{
    public class MainController : Controller
    {
        

        private UserContext _context { get; set; }

        public MainController(UserContext ctx) => _context = ctx;
        private bool checklogin()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }
        public IActionResult Index()
        {
            if(!checklogin()) { return RedirectToAction("index", "login"); }
            int Userid = (int)HttpContext.Session.GetInt32("UserId");
            List<Movie> movies = _context.mo.ToList();
            return View(movies);
        }

        [HttpPost]
        public IActionResult buy(int movieId)
        {
            Movie movie = _context.mo.Where(e=>e.MovieId == movieId).FirstOrDefault();
            if (movie != null)
            {
               
                return View("buy",movie);
            }
            else
            {
                return RedirectToAction("index");
            }
          

        }
        public IActionResult Ok(int movieId)
        {
            Movie movie = _context.mo.Where(e => e.MovieId == movieId).FirstOrDefault();
            if (movie != null)
            {

                return View("Ok", movie);
            }
            return View("Index");

        }

    }
}
