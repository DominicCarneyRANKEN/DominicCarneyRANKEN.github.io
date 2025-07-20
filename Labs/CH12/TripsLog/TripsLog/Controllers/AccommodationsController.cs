using Microsoft.AspNetCore.Mvc;
using TripsLog.Models;
using System.Linq;

namespace TripsLog.Controllers
{
    public class AccommodationsController : Controller
    {
        private readonly TripContext _context;

        public AccommodationsController(TripContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var accommodations = _context.Accommodations.ToList();
            return View(accommodations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Accommodation());
        }

        [HttpPost]
        public IActionResult Create(Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                _context.Accommodations.Add(accommodation);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accommodation);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var accommodation = _context.Accommodations.Find(id);
            if (accommodation != null && !_context.Trips.Any(t => t.AccommodationId == id))
            {
                _context.Accommodations.Remove(accommodation);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}