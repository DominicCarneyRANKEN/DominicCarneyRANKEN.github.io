using System.Security.Claims;
using System.Diagnostics;
using AnimeBookmarksV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace AnimeBookmarksV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnimeDbContext _context;
        private readonly TenorService _tenorService;


        public HomeController(AnimeDbContext context, TenorService tenorService)
        {
            _context = context;
            _tenorService = tenorService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm, int selectedGenreId = 0, int pageNumber = 1, int pageSize = 5, string title = null)
        {
            string slug = Animev2.GenerateSlug(title);
            var animeQuery = _context.Anime.Include(a => a.AnimeGenres).ThenInclude(ag => ag.Genre).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                animeQuery = animeQuery.Where(a => a.Title.Contains(searchTerm) ||
                a.Description.Contains(searchTerm));
            }

            if (selectedGenreId > 0)
            {
                animeQuery = animeQuery.Where(a => a.AnimeGenres.Any(ag => ag.GenreId == selectedGenreId));
            }

            var totalItems = await animeQuery.CountAsync();
            var animeList = await animeQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var genres = await _context.Genres.ToListAsync();
            var model = new AnimeGenreViewModel
            {
                Animesv2 = animeList,
                Genres = genres,
                SelectedGenreId = selectedGenreId,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm,
            };

            var gifUrl = await _tenorService.GetGifAsync();
            ViewBag.GifUrl = gifUrl;
            ViewData["Slug"] = slug;


            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> View(int id, string slug)
        {
            var anime = _context.Anime.Include(a => a.AnimeGenres).
            ThenInclude(ag => ag.Genre).FirstOrDefault(a => a.Id == id);

            if (anime == null)
            {
                return NotFound();
            }

            string generatedSlug = Animev2.GenerateSlug(anime.Title).ToLower();
            if (slug != generatedSlug)
            {
                return RedirectToAction(nameof(View), new { id, slug = generatedSlug });
            }
            return View(anime);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                TempData["ErrorMessage"] = "Username and Password are required.";
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync("CookieAuth", claimsPrincipal);
                HttpContext.Session.SetInt32("UserId", user.AccountId);
                HttpContext.Session.SetString("Username", user.Username);

                TempData["SuccessMessage"] = "Welcome back, " + user.Username + "!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid username or password.";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {

                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username || u.Email == model.Email);

                if (existingUser != null)
                {
                    if (existingUser.Username == model.Username)
                    {
                        ModelState.AddModelError("Username", "This username is already taken.");
                    }

                    if (existingUser.Email == model.Email)
                    {
                        ModelState.AddModelError("Email", "This email is already in use.");
                    }

                    return View(model); 
                }

             
                var newUser = new UserAccounts
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password 
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult RoleRequired()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



    }
}
