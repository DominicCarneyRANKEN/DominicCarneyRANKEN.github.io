namespace Project_6_1.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string? QuestionText { get; set; }

        public string? Response { get; set;  }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int TopicId { get; set; }

        public Topic? Topic { get; set; }

    }

   
}
