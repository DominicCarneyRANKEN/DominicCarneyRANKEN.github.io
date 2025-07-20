using AppointmentHOT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentHOT.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppointmentDbContext _context;

        public HomeController(AppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            var appointments = await _context.Appointments.Include(a => a.Customer).ToListAsync();
            return View(appointments);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("CreateAppointment", new { customerId = customer.CustomerId });
            }

            return View(customer);
        }



        public IActionResult CreateAppointment(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return RedirectToAction("CreateCustomer");  
            }

            var appointment = new Appointments { CustomerId = customerId };
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAppointment(Appointments appointment)
        {
            if (appointment.AppointmentDate <= DateTime.Now)
            {
                ModelState.AddModelError("AppointmentDate", "The appointment must be scheduled for the future.");
                return View(appointment);
            }

            if (appointment.AppointmentDate.Minute != 0)
            {
                ModelState.AddModelError("AppointmentDate", "The appointment must be after one hour");
                return View(appointment);
            }

            var endTime = appointment.AppointmentDate.AddHours(1);  
            var conflictingAppointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentDate >= appointment.AppointmentDate && a.AppointmentDate < endTime);

            if (conflictingAppointment != null)
            {
                ModelState.AddModelError("AppointmentDate", "The selected time slot is already taken.");
                return View(appointment);
            }

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
