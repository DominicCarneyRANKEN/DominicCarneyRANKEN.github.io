using GiftCardsShop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftCardsShop.GiftCardsBoss.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = "CookieAuth", Roles = "Admin")]
    public class AdminController : Controller

    {
        private readonly GiftCardDbContext _context;

        public AdminController(GiftCardDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var giftCards = _context.Cards.ToList();
            return View(giftCards);
        }

        public IActionResult Create()
        {
            return View(new GiftCards());
        }

        [HttpPost]
        public IActionResult Create(GiftCards giftCard)
        {
            if (ModelState.IsValid)
            {
                _context.Cards.Add(giftCard);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giftCard);
        }

        public IActionResult Edit(int id)
        {
            var giftCard = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (giftCard == null)
            {
                return NotFound();
            }
            return View(giftCard);
        }

        [HttpPost]
        public IActionResult Edit(GiftCards giftCard)
        {
            if (ModelState.IsValid)
            {
                _context.Cards.Update(giftCard);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giftCard);
        }

        public IActionResult Delete(int id)
        {
            var giftCard = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (giftCard == null)
            {
                return NotFound();
            }
            return View( giftCard);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var giftCard = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (giftCard != null)
            {
                _context.Cards.Remove(giftCard);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ManageUsers()
        {
            var users = _context.Users
                .Select(u => new ManageUserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Roles = u.Roles}).ToList();
                return View(users);
        }

        [HttpPost]
        public IActionResult ToggleAdminRole(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Roles = user.Roles == "Admin" ? "User" : "Admin";
            _context.SaveChanges();
            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid. Deletion cannot proceed.");
                return RedirectToAction("ManageUsers"); 
            }

            Console.WriteLine($"DeleteUser action triggered. ID received: {id}");

            var user = _context.Users.Find(id);
            if (user == null)
            {
                Console.WriteLine($"User with ID {id} not found.");
                return NotFound();
            }

            Console.WriteLine($"Deleting user with ID {id}");
            _context.Users.Remove(user);
            _context.SaveChanges();

            Console.WriteLine("User deleted successfully.");
            return RedirectToAction("ManageUsers");
        }


        public IActionResult RoleRequired()
        {
            return View();
        }

    }
}