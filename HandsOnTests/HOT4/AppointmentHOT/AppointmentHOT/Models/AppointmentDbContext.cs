using Microsoft.EntityFrameworkCore;
namespace AppointmentHOT.Models
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }

        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Username = "GuestOne",
                    Phonenumber = "1234"
                },
                new Customer
                {
                    CustomerId = 2,
                    Username = "GuestTwo",
                    Phonenumber = "5678"
                });

            modelBuilder.Entity<Appointments>().HasData(
                new Appointments
                {
                    Id = 1,
                    AppointmentDate = new DateTime(2025, 03, 19),
                    CustomerId = 1
                },

                new Appointments
                {
                    Id = 2,
                    AppointmentDate = new DateTime(2025, 03, 20),
                    CustomerId = 2
                });
        }
    }
}
