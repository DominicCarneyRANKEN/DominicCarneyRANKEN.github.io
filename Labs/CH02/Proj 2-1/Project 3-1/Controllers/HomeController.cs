using Microsoft.AspNetCore.Mvc;
using Project_3_1.Models;

namespace Project_3_1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new Discount();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Discount model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
    }
}
