using Microsoft.AspNetCore.Mvc;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class AdminController : Controller
    {
        private UserContext __context { get; set; }

        public AdminController(UserContext ctx) => __context = ctx;
        public IActionResult Index()
        {
            return View();  
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
         if(movie.MovieId !=null ) {
            
                __context.mo.Add(movie);
                __context.SaveChanges();


                return RedirectToAction("MovieAdded");
            }
         return View("AddMovie");

        }
        [HttpGet]
        public IActionResult DeleteMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteMovie(int movieId)
        {
            Movie m=__context.mo.Where(e=>e.MovieId==movieId).FirstOrDefault();
            if (m != null)
            {
                __context.mo.Remove(m);   
                __context.SaveChanges();
                return RedirectToAction("delete");
            }
            return View();

        }
    }

}
