using Microsoft.EntityFrameworkCore;

namespace Validation.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Username="EvanGudmestad",Password="admin", 
                ConfirmPassword="admin"
                });
            
        }


    }
}
