using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext Context { get; set; }

        public MovieController(MovieContext ctx)
        {
            Context = ctx;
        }

        [HttpGet]
        //id parameter is sent to the URL
        public IActionResult Delete(int id)
        {
            var movie = Context.Movies.Find(id);
            return View(movie);
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add New Movie";
            return View("Edit", new Movie());
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Movie";
            //LINQ query to find the movie with the given id - PK search
            var movie = Context.Movies.Find(id);
            return View(movie);
        }



        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                //Either add a new movie or edit a movie
                if(movie.MovieId == 0)
                {
                    Context.Movies.Add(movie);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                return View(movie);
            }
        }
    }
}
