using GiftCardsShop;
using GiftCardsShop.Models;
using Microsoft.AspNetCore.Mvc;

public class CartController : Controller
{
    private readonly GiftCardDbContext _context;

    public CartController(GiftCardDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var cart = GetCart();  
        var totalPrice = cart.Sum(item => (decimal)(item.GiftCard.Price * item.Quantity));  

        var model = new CartViewModel
        {
            CartItems = cart,
            TotalPrice = totalPrice
        };

        return View(model);  
    }


    public List<CartItems> GetCart()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItems>>("Cart");
        if (cart == null)
        {
            cart = new List<CartItems>();
        }
        return cart;
    }

    public IActionResult AddToCart(int giftCardId)
    {
        var cart = GetCart();
        var giftCard = _context.Cards.FirstOrDefault(c => c.Id == giftCardId);
        if (giftCard != null)
        {
            var cartItem = cart.FirstOrDefault(c => c.GiftCardId == giftCardId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItems { GiftCardId = giftCardId, GiftCard = giftCard, Quantity = 1 });
            }
            HttpContext.Session.SetObjectAsJson("Cart", cart); 
        }

        TempData["Message"] = "Item added to cart!";
        return RedirectToAction("Index");
    }

    public IActionResult RemoveFromCart(int giftCardId)
    {
        var cart = GetCart();
        var cartItem = cart.FirstOrDefault(c => c.GiftCardId == giftCardId);
        if (cartItem != null)
        {
            cart.Remove(cartItem);
            HttpContext.Session.SetObjectAsJson("Cart", cart); 
        }

        TempData["Message"] = "Item removed from cart!";
        return RedirectToAction("Index");
    }

    public IActionResult Checkout()
    {
        var cart = GetCart();
        if (cart.Any())
        {
            var order = new Orders
            {
                TotalPrice = cart.Sum(item => (decimal)(item.GiftCard.Price * item.Quantity)),
                Items = cart.Select(item => new CartItems
                {
                    GiftCardId = item.GiftCardId,
                    Quantity = item.Quantity
                }).ToList()
            };

            _context.Orders.Add(order); 
            _context.SaveChanges();

            cart.Clear();  
            HttpContext.Session.SetObjectAsJson("Cart", cart); 
            TempData["Message"] = "Thank you for your purchase!";
        }

        return RedirectToAction("Index");
    }
}

