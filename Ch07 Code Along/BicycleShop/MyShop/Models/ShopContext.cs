using Microsoft.EntityFrameworkCore;

namespace MyShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        public DbSet<Bicycle> Bicycles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Bicycle>().HasData(
                new Bicycle { Id = 1, Brand = "Trek", Model = "Emonda SL 6", Type="Hybrid", Year = 2013,Price = 2000, Color = "Black", ImageFileName = "images/" },
                new Bicycle { Id = 2, Brand = "Specialized", Model = "Diverge", Type="Hybrid", Year = 2021, Price = 1500, Color = "Blue" },
                new Bicycle { Id = 3, Brand = "Giant", Model = "Defy Advanced 2", Type="Road", Year = 2019, Price = 1800, Color = "Silver"}
                );
        }
    }
}
