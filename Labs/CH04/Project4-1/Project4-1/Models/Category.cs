namespace Project4_1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

     
        public List<Contact>? Contacts { get; set; }
    }
}
