namespace GiftCardsShop.Models
{
    public class CartItems
    {
        public int GiftCardId { get; set; }
        public GiftCards GiftCard { get; set; }
        public int Quantity { get; set; }
    }
}
