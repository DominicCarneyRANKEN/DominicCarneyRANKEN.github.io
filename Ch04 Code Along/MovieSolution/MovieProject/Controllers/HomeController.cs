using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext Context { get; set;  }
        //Constructor accepts DB context object that's enabled by DI

        public HomeController(MovieContext ctx)
        {
            Context = ctx;
        }

        public IActionResult Index()
        {
            var movies = Context.Movies.OrderBy(m => m.Name).ToList();
            return View(movies);
        }

        
    }
}
