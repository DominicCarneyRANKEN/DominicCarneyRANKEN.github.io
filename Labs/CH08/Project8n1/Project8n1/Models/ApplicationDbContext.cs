using Microsoft.EntityFrameworkCore;

namespace Project8n1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "Paris",
                    StartDate = new DateTime(2025, 6, 1),
                    EndDate = new DateTime(2025, 6, 10)
                },
                new Trip
                {
                    TripId = 2,
                    Destination = "Tokyo",
                    StartDate = new DateTime(2025, 7, 15),
                    EndDate = new DateTime(2025, 7, 25)
                }
            );

            modelBuilder.Entity<Accommodation>().HasData(
                new Accommodation
                {
                    AccommodationId = 1,
                    HotelName = "Hotel Le Meurice",
                    Email = "contact@lemeurice.com",  
                    Phone = "+33 1 44 58 10 10",      
                    TripId = 1
                },
                new Accommodation
                {
                    AccommodationId = 2,
                    HotelName = "Shinjuku Granbell Hotel",
                    Email = "info@shinjukugranbell.com",
                    Phone = "+81 3-6406-3939",          
                    TripId = 2
                }
            );

            modelBuilder.Entity<Activity>().HasData(
                new Activity
                {
                    ActivityId = 1,
                    ActivityName = "Eiffel Tower Visit",
                    TripId = 1
                },
                new Activity
                {
                    ActivityId = 2,
                    ActivityName = "Tokyo Skytree Visit",
                    TripId = 2
                }
            );
        }
    }
}
