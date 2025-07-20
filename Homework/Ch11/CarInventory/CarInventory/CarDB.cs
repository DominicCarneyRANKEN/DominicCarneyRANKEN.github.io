using Microsoft.EntityFrameworkCore;

namespace CarInventory
{
    public class CarDB : DbContext
    {
        public CarDB(DbContextOptions<CarDB> options) : base(options) { }

        public DbSet<Car> Cars { get; set; } //Creating a Cars table in the DB
    }
}
