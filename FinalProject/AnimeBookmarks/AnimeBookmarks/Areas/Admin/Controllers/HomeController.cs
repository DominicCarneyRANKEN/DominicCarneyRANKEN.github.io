using AnimeBookmarks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AnimeBookmarks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var animeList = await _context.Animes.ToListAsync(); 
            var genres = animeList.Select(a => a.Genre).Distinct().ToList();

            var model = new AnimeGenreViewModel
            {
                Genres = genres,
                Animes = animeList
            };

            return View(model); 
        }

    }
}
