using Microsoft.EntityFrameworkCore;
namespace Project4_1.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friends" },
                new Category { CategoryId = 3, Name = "Work" }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact { ContactId = 1, FirstName = "Nicholas", LastName = "McClain", PhoneNumber = "123-456-789", Email = "nicholasm@gmail.com", CategoryId = 1, DateAdded = new DateTime(2025, 1, 29) },
                new Contact { ContactId = 2, FirstName = "Tommy", LastName = "Lester", PhoneNumber = "987-654-321", Email = "tommyl@outlook.com", CategoryId = 2, DateAdded = new DateTime(2025, 1, 31)}
            );
        }
    }
}
