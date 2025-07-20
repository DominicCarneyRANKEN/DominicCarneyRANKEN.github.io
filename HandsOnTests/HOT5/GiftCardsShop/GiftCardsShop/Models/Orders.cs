namespace GiftCardsShop.Models
{
    public class Orders
    {
       public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; }

        public List<CartItems> Items { get; set; }
    }
}
