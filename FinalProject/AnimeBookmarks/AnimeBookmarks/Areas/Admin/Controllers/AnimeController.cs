using AnimeBookmarks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AnimeBookmarks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnimeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string genre, string searchString, int? pageNumber)
        {
            var animeList = await _context.Animes.ToListAsync();

            if (!string.IsNullOrEmpty(genre))
            {
                animeList = animeList.Where(a => a.Genre == genre).ToList();
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                animeList = animeList.Where(a => a.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            int pageSize = 5; 
            int currentPage = pageNumber ?? 1; 

            var pagedAnimes = animeList.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var genres = animeList.Select(a => a.Genre).Distinct().ToList();
            var model = new AnimeGenreViewModel
            {
                Genres = genres,
                Animes = pagedAnimes,
                SelectedGenre = genre,
                SearchString = searchString,
                PageNumber = currentPage,
                TotalPages = (int)Math.Ceiling(animeList.Count / (double)pageSize)
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Anime());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Anime anime)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                return View(anime);
            }

            anime.Slug = Anime.GenerateSlug(anime.Title);
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Anime successfully added!";
            return RedirectToAction("Index", "Anime", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var anime = _context.Animes.Find(id);

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Anime anime)
        {
            if (id != anime.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                return View(anime);
            }

            try
            {
                anime.Slug = Anime.GenerateSlug(anime.Title);
                _context.Entry(anime).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Anime successfully updated!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Animes.Any(a => a.Id == anime.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Index", "Anime", new { area = "Admin" });
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var anime = _context.Animes.Find(id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime); 
        }


        public IActionResult Index()
        {
            var animes = _context.Animes.ToList();

            return View(animes);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }

            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Anime successfully deleted!";
            return RedirectToAction("Index", "Anime", new { area = "Admin" });
        }




        private string GenerateSlug(string title)
        {
            return string.IsNullOrEmpty(title) ? string.Empty : title.ToLower().Replace(" ", "-");
        }
    }
}

