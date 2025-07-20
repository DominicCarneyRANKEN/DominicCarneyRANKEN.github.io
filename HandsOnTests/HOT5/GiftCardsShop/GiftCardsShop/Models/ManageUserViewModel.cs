namespace GiftCardsShop.Models
{
    public class ManageUserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public bool IsAdmin => Roles == "Admin";

        public string Roles { get; set; } = "User";
    }
}
