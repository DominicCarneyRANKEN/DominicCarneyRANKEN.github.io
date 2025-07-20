namespace GiftCardsShop.Models
{
    public class CartViewModel
    {
        public List<CartItems> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
