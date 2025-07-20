using Microsoft.AspNetCore.Mvc;
using TripsLog.Models;
using System.Linq;

namespace TripsLog.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly TripContext _context;

        public ActivitiesController(TripContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var activities = _context.Activities.ToList();
            return View(activities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var destination = await _context.Activities.FindAsync(id);

            if(destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = _context.Activities.Find(id);
            if(activity == null)
            {
                return NotFound();
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
