using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuarterlySalers.Models;

namespace QuarterlySalers.Controllers
{
    public class HomeController : Controller
    {

        private readonly SalesDbContext _context;

        public HomeController(SalesDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(int? employeeId)
        {
            var sales = _context.Sales.Include(s => s.Employee).AsQueryable();

            if (employeeId.HasValue)
            {
                sales = sales.Where(s => s.EmployId == employeeId.Value);
            }

            var employeeSelectList = new SelectList(_context.Employees, "EmployId", "Firstname");
            ViewData["Employees"] = employeeSelectList;

            return View(sales.ToList());
        }



        public IActionResult CreateEmployee()
        {
            ViewData["Employees"] = new SelectList(_context.Employees, "EmployId", "Firstname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee(Employee employee)
        {
            ViewData["Employees"] = new SelectList(_context.Employees, "EmployId", "Firstname");

            if (ModelState.IsValid)
            {
                var existingEmployee = _context.Employees
                    .FirstOrDefault(e => e.Firstname == employee.Firstname && e.Lastname == employee.Lastname && e.DOB == employee.DOB);
                if (existingEmployee != null)
                {
                    ModelState.AddModelError("", "An employee with the same name and date of birth already exists.");
                    return View(employee);
                }

                if (employee.ManagerId.HasValue && employee.ManagerId == employee.EmployId)
                {
                    ModelState.AddModelError("", "An employee cannot be their own manager.");
                    return View(employee);
                }

                _context.Employees.Add(employee);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        public IActionResult CreateSales()
        {
            ViewData["Employees"] = new SelectList(_context.Employees, "EmployId", "Firstname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSales(Sales sales)
        {
            if (ModelState.IsValid)
            {
                var existingSales = _context.Sales
                    .FirstOrDefault(s => s.EmployId == sales.EmployId && s.Year == sales.Year && s.Quarter == sales.Quarter);

                if (existingSales != null)
                {
                    ModelState.AddModelError("", "Sales for this year are already in the database.");
                    ViewData["Employees"] = new SelectList(_context.Employees, "EmployId", "Firstname");
                    return View(sales);  
                }

                _context.Sales.Add(sales);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Employees"] = new SelectList(_context.Employees, "EmployId", "Firstname");
            return View(sales);  
        }


    }
}
