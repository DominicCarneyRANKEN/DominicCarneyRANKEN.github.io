using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Content("Hello from Home Controller, Index Action");
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            return Content($"Hello from Home Controller, Index Action, id of {id}");
        }

        public IActionResult Privacy()
        {
            return Content($"Hello from Home Controller, Privacy Action");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
