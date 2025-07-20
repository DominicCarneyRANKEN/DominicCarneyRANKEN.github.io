using System.Diagnostics;
using System.Security.Claims;
using GiftCardsShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GiftCardsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly GiftCardDbContext _context;

        public HomeController(GiftCardDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(string searchTerm)
        {
            var giftCards = _context.Cards.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                giftCards = giftCards.Where(g => g.Name.Contains(searchTerm));
            }

            return View(giftCards.ToList()); 
        }

        public IActionResult View(string slug)
        {
            var giftCard = _context.Cards.FirstOrDefault(g => g.Slug == slug);

            if (giftCard == null)
            {
                return NotFound();
            }

            return View(giftCard);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new UserAccounts
                {
                    Username = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password, 
                    Roles = "User"
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                HttpContext.Session.SetString("UserId", newUser.Id.ToString());
                HttpContext.Session.SetString("Username", newUser.Username);
                HttpContext.Session.SetString("Roles", newUser.Roles);


                return RedirectToAction("Index");
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "Username and password are required.");
                return View(model);
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == model.Username);

            if (user == null || user.Password != model.Password)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(model);
            }

            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Roles", user.Roles);
            HttpContext.Session.SetInt32("UserId", user.Id);

            var claims = new List<Claim>
    {
         
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Roles)
    };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth"); 
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index");
        }


    }
}
