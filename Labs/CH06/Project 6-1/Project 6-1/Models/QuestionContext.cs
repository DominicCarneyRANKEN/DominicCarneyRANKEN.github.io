using Microsoft.EntityFrameworkCore;
namespace Project_6_1.Models
{
    public class QuestionContext : DbContext
    {
        public DbSet<Question> Question { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Topic> Topics { get; set; } = null!;

        public QuestionContext(DbContextOptions<QuestionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryType = "General" },
                new Category { CategoryId = 2, CategoryType = "History" }
            );

           
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = 1, TheTopic = "Bootstrap" },
                new Topic { TopicId = 2, TheTopic = "C#" },
                new Topic { TopicId = 3, TheTopic = "JavaScript" }
            );

            
            modelBuilder.Entity<Question>().HasData(
                new Question { QuestionId = 1, QuestionText = "What is Bootstrap?", Response = "A CSS framework for creating responsive web apps for multiple screen sizes.", CategoryId = 1, TopicId = 1 },
                new Question { QuestionId = 2, QuestionText = "What is C#?", Response = "A general purpose object-oriented language that uses a concise, Java-like syntax.", CategoryId = 1, TopicId = 2 },
                new Question { QuestionId = 3, QuestionText = "What is JavaScript?", Response = "A general purpose scripting language that executes in a web browser.", CategoryId = 1, TopicId = 3 },
                new Question { QuestionId = 4, QuestionText = "When was Bootstrap first released?", Response = "In 2011.", CategoryId = 2, TopicId = 1 },
                new Question { QuestionId = 5, QuestionText = "When was C# first released?", Response = "In 2002.", CategoryId = 2, TopicId = 2 }
            );
        }
    }
}
