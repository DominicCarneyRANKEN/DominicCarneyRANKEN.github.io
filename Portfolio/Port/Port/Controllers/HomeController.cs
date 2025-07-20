using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Port.Models;

namespace Port.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            return View();
        }

        public IActionResult AboutMe()
        {
            ViewData["Title"] = "About";
            return View();
        }
    }
}
