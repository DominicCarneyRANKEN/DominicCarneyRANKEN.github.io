using AnimeBookmarks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
        var genres = animeList.Select(a => a.Genre).Distinct().ToList(); // Get unique genres

        var model = new AnimeGenreViewModel
        {
            Genres = genres,
            Animes = animeList
        };

        return View(model); // ? Now it matches @model AnimeGenreViewModel
    }


    [HttpGet]
    public async Task<IActionResult> View(int id, string slug)
    {
        var anime = await _context.Animes.FindAsync(id);
        if (anime == null)
        {
            return NotFound();
        }

        string generatedSlug = Anime.GenerateSlug(anime.Title).ToLower(); // Ensure slug is lowercase
        if (slug != generatedSlug)
        {
            return RedirectToAction(nameof(View), new { id, slug = generatedSlug });
        }

        return View(anime);
    }
}
