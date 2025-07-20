namespace Project_6_1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryType { get; set; } = string.Empty;

        public List<Question>? Questions { get; set; }
    }
}
