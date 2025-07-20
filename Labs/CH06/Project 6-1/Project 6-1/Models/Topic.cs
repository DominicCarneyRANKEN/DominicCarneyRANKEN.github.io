namespace Project_6_1.Models
{
    public class Topic
    {
        public int TopicId { get; set; }

        public string TheTopic { get; set; } = string.Empty;

        public List<Question>? Questions { get; set; }
    }
}
