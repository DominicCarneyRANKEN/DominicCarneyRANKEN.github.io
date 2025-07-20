using System.Diagnostics;
using GiftCardsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftCardsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly GiftCardDbContext _context;

        public HomeController(GiftCardDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(string searchTerm)
        {
            var giftCards = _context.Cards.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                giftCards = giftCards.Where(g => g.Name.Contains(searchTerm));
            }

            return View(giftCards.ToList()); 
        }

        public IActionResult View(string slug)
        {
            var giftCard = _context.Cards.FirstOrDefault(g => g.Slug == slug);

            if (giftCard == null)
            {
                return NotFound();
            }

            return View(giftCard);
        }
    }
}
