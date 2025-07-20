using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project8n1.Models;
using Microsoft.EntityFrameworkCore;

namespace Project8n1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var trips = _context.Trips.ToList(); 
            return View(trips);  
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
