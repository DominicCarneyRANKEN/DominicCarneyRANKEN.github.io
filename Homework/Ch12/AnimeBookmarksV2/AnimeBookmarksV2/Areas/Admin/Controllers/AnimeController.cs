using AnimeBookmarksV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeBookmarksV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AnimeController : Controller
    {
        private readonly AnimeDbContext _context;

        private readonly GenreService _genreService;
        public AnimeController(AnimeDbContext context, GenreService genreService)
        {
            _context = context;
            _genreService = genreService;
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



        [HttpGet]
        public IActionResult Create()
        {
            var genres = _context.Genres.ToList();
            ViewBag.Genres = genres;
            return View(new Animev2());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Animev2 anime, IFormFile imageFile, List<int> selectedGenres)
        {
            Console.WriteLine($"Title: {anime.Title}");
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                ViewBag.Genres = _context.Genres.ToList();
                return View(anime);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Genres = _context.Genres.ToList();
                return View(anime);
            }

            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "The imageFile field is required.");
            }


            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AnimeImages");
                if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadDir, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                anime.ImagePath = "/AnimeImages/" + fileName;
            }

            _context.Anime.Add(anime);
            await _context.SaveChangesAsync();

            if (selectedGenres != null && selectedGenres.Any())
            {
                foreach (var genreId in selectedGenres)
                {
                    _context.AnimeGenres.Add(new AnimeGenre
                    {
                        AnimeId = anime.Id,
                        GenreId = genreId
                    });
                }
                await _context.SaveChangesAsync();
            }

            TempData["SuccessMessage"] = "Anime successfully added!";
            return RedirectToAction("Index", "Anime", new { area = "Admin" });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            if (anime == null) return NotFound();

            var genres = await _context.Genres.ToListAsync();
            ViewBag.Genres = genres;

            return View(anime);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Animev2 anime, IFormFile imageFile, List<int> selectedGenres)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
                ViewBag.Genres = await _context.Genres.ToListAsync();
                return View(anime);
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AnimeImages");
                if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadDir, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                anime.ImagePath = "/AnimeImages/" + fileName;
            }

            try
            {
                _context.Entry(anime).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var existingGenres = _context.AnimeGenres.Where(ag => ag.AnimeId == anime.Id).ToList();
                _context.AnimeGenres.RemoveRange(existingGenres);

                foreach (var genreId in selectedGenres)
                {
                    _context.AnimeGenres.Add(new AnimeGenre
                    {
                        AnimeId = anime.Id,
                        GenreId = genreId
                    });
                }

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Anime successfully updated!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Anime.Any(a => a.Id == anime.Id))
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

        [HttpPost]
        public async Task<IActionResult> SelectGenres(GenreSelectionViewModel viewModel)
        {
            foreach (var genreId in viewModel.SelectedGenreIds)
            {
                _context.AnimeGenres.Add(new AnimeGenre
                {
                    AnimeId = viewModel.AnimeId,
                    GenreId = genreId
                });
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Genres successfully associated!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            if (anime == null) return NotFound();
            return View(anime);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            if (anime != null)
            {
                _context.Anime.Remove(anime);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ManageUsers()
        {
            var users = _context.Users
                .Select(u => new ManageUserViewModel
                {
                    Id = u.AccountId,
                    Username = u.Username,
                    Role = u.Role
                })
                .ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult CreateGenre()
        {
            return View(new Genre());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }

            var existingGenre = await _context.Genres.FirstOrDefaultAsync(u => u.Name == genre.Name);
            if(existingGenre != null)
            {
                Console.WriteLine("Genre already exists");
                ModelState.AddModelError("Name", "Genre already exists");
                return View(genre);
            }

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Genre successfully added :) ";
            return RedirectToAction("Genres");
        }

        [HttpGet]
        public async Task<IActionResult> EditGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null) return NotFound();

            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> EditGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }

            try
            {
                _context.Entry(genre).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Genre successfully updated!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!_context.Genres.Any(g => g.Id == genre.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Genres");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null) return NotFound();
            return View(genre);
        }

        [HttpPost, ActionName("DeleteGenre")]
        public async Task<IActionResult> DeleteGenreConfirmed(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                var animeGenres = _context.AnimeGenres.Where(ag => ag.GenreId == genre.Id);
                _context.AnimeGenres.RemoveRange(animeGenres);

                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Genre successfully deleted!";
            }

            return RedirectToAction("Genres");
        }



        [HttpGet]
        public async Task<IActionResult> Genres()
        {
            var genres = await _context.Genres.ToListAsync();
            return View(genres);
        }


    }
}