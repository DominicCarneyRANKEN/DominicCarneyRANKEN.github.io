using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Project7_1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About Page";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact Page";
            var contacts = new[] {
                new { Name = "Nick Carney", Email = "niko@AlienwareAlpha.com" },
                new { Name = "Lebron James", Email = "lebron@nbaplayer2k.com" }
            };
            return View(contacts);
        }
    }
}

