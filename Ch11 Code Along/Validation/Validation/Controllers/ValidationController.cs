using Microsoft.AspNetCore.Mvc;
using Validation.Models; 

namespace Validation.Controllers
{
    public class ValidationController : Controller
    {
        private readonly CustomerContext _context;

        public ValidationController(CustomerContext context)
        {
            _context = context;
        }

        public JsonResult CheckUserName(string username)
        {
            var user = _context.Customers.FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Username {username} is already in use.");
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
