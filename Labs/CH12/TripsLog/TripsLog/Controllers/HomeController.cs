using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripsLog.Models;

namespace TripsLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly TripContext _context;

        public HomeController(TripContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       

    }
}
