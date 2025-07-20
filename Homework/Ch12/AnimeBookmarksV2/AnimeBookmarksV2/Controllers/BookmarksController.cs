using AnimeBookmarksV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeBookmarksV2.Controllers
{
    public class BookmarksController : Controller
    {
        private readonly AnimeDbContext _context;

        public BookmarksController(AnimeDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int animeId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            var existingBookmark = await _context.Bookmarks.FirstOrDefaultAsync(b => b.AccountId == userId.Value && b.AnimeId == animeId);

            if (existingBookmark == null)
            {
                var bookmark = new UserBookmarks
                {
                    AccountId = userId.Value, 
                    AnimeId = animeId
                };

                _context.Bookmarks.Add(bookmark);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Bookmarks");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int animeId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            var bookmark = await _context.Bookmarks.FirstOrDefaultAsync(b => b.AccountId == userId &&
            b.AnimeId == animeId);

            if (bookmark != null)
            {
                _context.Bookmarks.Remove(bookmark);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId"); 
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            var bookmarks = await _context.Bookmarks
                .Where(b => b.AccountId == userId.Value) 
                .Include(b => b.Anime)
                .ToListAsync();

            return View(bookmarks);
        }

    }
}
