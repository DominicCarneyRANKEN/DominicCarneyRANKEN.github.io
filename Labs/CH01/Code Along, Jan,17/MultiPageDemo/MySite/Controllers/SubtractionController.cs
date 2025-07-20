using Microsoft.AspNetCore.Mvc;
using MySite.Models;

namespace MySite.Controllers
{
    public class SubtractionController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Subtraction subtraction = new Subtraction();
            subtraction.Difference = 0;
            return View(subtraction);
        }

        [HttpPost]

        public IActionResult Index(Subtraction subtraction)
        {
            subtraction.CalculateDifference();
            return View(subtraction);
        }
    }
}
