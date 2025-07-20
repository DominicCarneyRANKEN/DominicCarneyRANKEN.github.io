using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuarterlySalers.Models;

namespace QuarterlySalers.Controllers
{
    [Authorize] 
    public class AdminController : Controller
    {
        private readonly SalesDbContext _context;

        public AdminController(SalesDbContext context)
        {
            _context = context;
        }

        public IActionResult ManageUsers()
        {

            var users = _context.Users
                .Select(u => new ManageUserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role
                })
                .ToList();

            return View(users);
        }

        [HttpPost]
        public IActionResult ToggleAdminRole(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Role = user.Role == "Admin" ? "User" : "Admin";
            _context.SaveChanges();

            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("ManageUsers");
        }
    }
}
