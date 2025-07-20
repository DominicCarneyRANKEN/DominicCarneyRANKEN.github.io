using AnimeBookmarksV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AnimeBookmarksV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly AnimeDbContext _context;

        public HomeController(AnimeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var animeList = await _context.Anime.Include(a => a.AnimeGenres)
                .ThenInclude(ag => ag.Genre).ToListAsync();

            var animeWithSlugs = animeList.Select(anime => new
            {
                Anime = anime,
                Slug = Animev2.GenerateSlug(anime.Title)
            }).ToList();
            var model = new AnimeGenreViewModel
            {
                Animesv2 = animeList
            };

            ViewData["AnimeWithSlugs"] = animeWithSlugs;

            return View(model);


        }


    }
}
