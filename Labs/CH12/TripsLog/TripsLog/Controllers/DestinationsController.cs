using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsLog.Models;

namespace TripsLog.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly TripContext _context;

        public DestinationsController(TripContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "TripContext is not initialized.");
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _context.Destinations.ToListAsync();
            return View(destinations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Destination());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(destination);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);

            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);

            if (destination == null)
            {
                return NotFound();
            }

            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}