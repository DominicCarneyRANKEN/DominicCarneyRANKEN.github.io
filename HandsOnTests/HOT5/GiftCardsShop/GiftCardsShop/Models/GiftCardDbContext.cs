using Microsoft.EntityFrameworkCore;

namespace GiftCardsShop.Models
{
    public class GiftCardDbContext : DbContext 
    {
        public DbSet<GiftCards> Cards { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<UserAccounts> Users { get; set; }

        public GiftCardDbContext(DbContextOptions<GiftCardDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiftCards>().HasData(
                new GiftCards { Id = 1, Name = "Fortnite 1000 V-Bucks", Price = 8.99, Description = "Fortnite V Bucks used to buy cosmetics from the item shop", Img = "", Slug = "fortnite-v-bucks" },
                new GiftCards { Id = 2, Name = "PS 25$ Gift Card", Price = 25.00, Description = "PS Gift Card used to make purchases on PS Store", Img = "", Slug = "ps-gift-card" },
                new GiftCards { Id = 3, Name = "PS Plus Essential 12 Month Subscription", Price = 79.99, Description = "Enhance your PlayStation experience with core features, including online multiplayer access, monthly games, exclusive discounts, and more.", Img = "", Slug = "ps-plus" },
                new GiftCards { Id = 4, Name = "DoorDash 50$ Gift Card", Price = 50.00, Description = "Give the gift of delivery with a DoorDash gift card. The DoorDash app connects your favorite people with the best of their neighborhood.", Img = "", Slug = "doordash-gift-card" },
                new GiftCards { Id = 5, Name = "Roblox $25 Gift Card", Price = 25.00, Description = "Roblox, Roblox Gift Card", Img = "", Slug = "roblox-gift-card" });

            modelBuilder.Entity<CartItems>()
                .HasKey(ci => ci.GiftCardId);

            modelBuilder.Entity<CartItems>()
                .HasOne(ci => ci.GiftCard)
                .WithMany()
                .HasForeignKey(ci => ci.GiftCardId);

            modelBuilder.Entity<UserAccounts>().HasData(
                new UserAccounts { Id = 1, Username = "Guest", Email = "guest@email.com", FirstName = "Josh", LastName = "Nickels", Password = "password123", Roles = "User" }
                );
        }
    }
}