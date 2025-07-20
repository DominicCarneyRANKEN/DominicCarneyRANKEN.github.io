using GiftCardsShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftCardsShop.GiftCardsBoss.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly GiftCardDbContext _context;

        public AdminController(GiftCardDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var giftCards = _context.Cards.ToList();
            return View("~/GiftCardsBoss/Admin/Views/Cards/Index.cshtml", giftCards);
        }

        public IActionResult Create()
        {
            return View("~/GiftCardsBoss/Admin/Views/Cards/Create.cshtml", new GiftCards());
        }

        [HttpPost]
        public IActionResult Create(GiftCards giftCard)
        {
            if (ModelState.IsValid)
            {
                _context.Cards.Add(giftCard);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/GiftCardsBoss/Admin/Views/Cards/Create.cshtml", giftCard);
        }

        public IActionResult Edit(int id)
        {
            var giftCard = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (giftCard == null)
            {
                return NotFound();
            }
            return View("~/GiftCardsBoss/Admin/Views/Cards/Edit.cshtml", giftCard);
        }

        [HttpPost]
        public IActionResult Edit(GiftCards giftCard)
        {
            if (ModelState.IsValid)
            {
                _context.Cards.Update(giftCard);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/GiftCardsBoss/Admin/Views/Cards/Edit.cshtml", giftCard);
        }

        public IActionResult Delete(int id)
        {
            var giftCard = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (giftCard == null)
            {
                return NotFound();
            }
            return View("~/GiftCardsBoss/Admin/Views/Cards/Delete.cshtml", giftCard);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var giftCard = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (giftCard != null)
            {
                _context.Cards.Remove(giftCard);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}