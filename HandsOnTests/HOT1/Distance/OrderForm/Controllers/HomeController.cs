using System.Diagnostics;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using OrderForm.Models;

namespace OrderForm.Controllers
{
    public class HomeController : Controller
    {
        private const decimal ShirtPrice = 15.00m;
        private const decimal TaxRate = 0.08m;

        
        private Dictionary<string, decimal> discountCodes = new Dictionary<string, decimal>
        {
            { "6175", 0.30m }, 
            { "1390", 0.20m }, 
            { "BB88", 0.10m }
        };

       
        [HttpGet]
        public IActionResult Index()
        {
           
            return View(new Order());
        }

       
        [HttpPost]
        public IActionResult Order(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", order); 
            }

   
            int quantity = order.Quantity ?? 0; 

            decimal subtotal = quantity * ShirtPrice;
            decimal tax = subtotal * TaxRate;
            decimal total = subtotal + tax;

            if (!string.IsNullOrEmpty(order.Discount))
            {
                if (discountCodes.ContainsKey(order.Discount))
                {
                    decimal discount = discountCodes[order.Discount];
                    subtotal -= subtotal * discount;
                    total = subtotal + tax;
                }
                else
                {
                    
                    ModelState.AddModelError("Discount", "Invalid discount code.");
                    return View("Index", order);
                }
            }

            ViewBag.Subtotal = subtotal.ToString("C");
            ViewBag.Tax = tax.ToString("C");
            ViewBag.Total = total.ToString("C");

            return View("Index", order);
        }
    }
}

