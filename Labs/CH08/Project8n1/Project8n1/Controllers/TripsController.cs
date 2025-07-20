using Microsoft.AspNetCore.Mvc;
using Project8n1.Models;
using Microsoft.EntityFrameworkCore;

namespace Project8n1.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var trips = _context.Trips.ToList();
            return View(trips);
        }

        public IActionResult AddTrip()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTrip(TripViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Store only simple data in TempData, not the whole object
                TempData["TripId"] = model.Trip.TripId;
                TempData["Destination"] = model.Trip.Destination;
                TempData["StartDate"] = model.Trip.StartDate;
                TempData["EndDate"] = model.Trip.EndDate;

                return RedirectToAction("AddAccommodation");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddAccommodation()
        {
            ViewBag.SubHeader = "Add Accommodation";

            var accommodationDetails = TempData["AccommodationDetails"] as string;

            if (!string.IsNullOrEmpty(accommodationDetails))
            {
                ViewBag.AccommodationDetails = accommodationDetails;
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddAccommodation(Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                var trip = new Trip
                {
                    TripId = (int)TempData["TripId"],
                    Destination = (string)TempData["Destination"],
                    StartDate = (DateTime)TempData["StartDate"],
                    EndDate = (DateTime)TempData["EndDate"]
                };

                _context.Trips.Add(trip);
                _context.Accommodations.Add(accommodation);
                _context.SaveChanges();

                TempData.Clear();

                return RedirectToAction("AddActivity"); 
            }

            return View();
        }



        public IActionResult AddActivity()
        {
            ViewBag.SubHeader = "Add Activity";
            return View();
        }

        [HttpPost]
        public IActionResult AddActivity(Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Activities.Add(activity);
                _context.SaveChanges();

                TempData.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }
    }
}
