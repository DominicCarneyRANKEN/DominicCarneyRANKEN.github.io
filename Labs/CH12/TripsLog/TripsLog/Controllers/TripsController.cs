using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsLog.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TripsLog.Controllers
{
    public class TripsController : Controller
    {
        private readonly TripContext _context;

        public TripsController(TripContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var trips = await _context.Trips
         .Include(t => t.Destination) 
         .Include(t => t.Accommodation) 
         .Include( t => t.TripActivities)
         .ThenInclude(ta => ta.Activity)
         .ToListAsync();

            return View(trips); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Destinations = _context.Destinations
                .Select(d => new SelectListItem
                {
                    Value = d.DestinationId.ToString(),
                    Text = d.Name
                })
                .ToList();

            ViewBag.Accommodations = _context.Accommodations
                .Select(a => new SelectListItem
                {
                    Value = a.AccommodationId.ToString(),
                    Text = a.Name
                })
                .ToList();

            ViewBag.Activities = _context.Activities
                .Select(a => new SelectListItem
                {
                    Value = a.ActivityId.ToString(),
                    Text = a.Name
                })
                .ToList();

            return View(new Trip());
        }

        [HttpPost]
        public IActionResult Create(Trip trip, List<int> TripActivities)
        {
            if (ModelState.IsValid)
            {
                trip.Destination = _context.Destinations.Find(trip.DestinationId);
                trip.Accommodation = _context.Accommodations.Find(trip.AccommodationId);

                _context.Trips.Add(trip);
                _context.SaveChanges();

                foreach (var activityId in TripActivities)
                {
                    var tripActivity = new TripActivity
                    {
                        TripId = trip.TripId,
                        ActivityId = activityId
                    };
                    _context.TripActivities.Add(tripActivity);
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Destinations = _context.Destinations
                .Select(d => new SelectListItem { Value = d.DestinationId.ToString(), Text = d.Name })
                .ToList();
            ViewBag.Accommodations = _context.Accommodations
                .Select(a => new SelectListItem { Value = a.AccommodationId.ToString(), Text = a.Name })
                .ToList();
            ViewBag.Activities = _context.Activities
                .Select(a => new SelectListItem { Value = a.ActivityId.ToString(), Text = a.Name })
                .ToList();

            return View(trip);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _context.Trips
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            _context.Trips.Remove(trip); 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
    }
}
