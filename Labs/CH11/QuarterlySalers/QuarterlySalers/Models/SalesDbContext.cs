using Microsoft.EntityFrameworkCore;
namespace QuarterlySalers.Models
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) 
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>()
        .HasOne(s => s.Employee)         
        .WithMany(e => e.Sale)           
        .HasForeignKey(s => s.EmployId)  
        .HasConstraintName("FK_Sales_Employee");


            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployId = 1,
                    Firstname = "Nickels",
                    Lastname = "M",
                    DOB = new DateTime(2002, 10, 13),
                    DateOfHire = new DateTime(2024, 4, 16),
                    ManagerId = null,
                },
                new Employee
                {
                    EmployId = 2,
                    Firstname = "Rigby",
                    Lastname = "I",
                    DOB = new DateTime(2003, 12, 4),
                    DateOfHire = new DateTime(2025, 1, 5),
                    ManagerId = 1,
                }
            );

            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    Id = 1,
                    EmployId = 1,  
                    Quarter = 1,
                    Year = 2024,
                    Amount = 1000
                },
                new Sales
                {
                    Id = 2,
                    EmployId = 2, 
                    Quarter = 2,
                    Year = 2025,
                    Amount = 2000
                }
            );

        }
    }
}
