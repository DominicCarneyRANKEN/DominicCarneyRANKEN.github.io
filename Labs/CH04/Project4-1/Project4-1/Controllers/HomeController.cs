using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project4_1.Models;

namespace Project4_1.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext Context { get; }

        public HomeController(ContactContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            var contacts = Context.Contacts.Include(c => c.Category).ToList();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var categories = Context.Categories
                .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name })
                .ToList();

            ViewBag.Categories = categories;
            return View("Edit", new Contact());  
        }


        [HttpGet]
        public IActionResult View(int id)
        {
            var contact = Context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View("View", contact);  
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = Context.Contacts.Find(id);
            if (contact == null) return NotFound();

            ViewBag.Categories = Context.Categories
                .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name })
                .ToList();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Save(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    contact.DateAdded = DateTime.Now;  
                    Context.Contacts.Add(contact);
                }
                else
                {
                    Context.Contacts.Update(contact);
                }

                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            var categories = Context.Categories.ToList();
            ViewBag.Categories = categories;
            return View("Edit", contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = Context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);  
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var contact = Context.Contacts.Find(id);
            if (contact != null)
            {
                Context.Contacts.Remove(contact);
                Context.SaveChanges();
            }
            return RedirectToAction("Index");  
        }

    }
}


