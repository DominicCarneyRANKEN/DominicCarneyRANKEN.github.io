using Microsoft.EntityFrameworkCore;
namespace AnimeBookmarks.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Anime> Animes { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>().HasData(
                new Anime( 1 ,"Blue Exorcist", "Action",
                          "The story revolves around Rin Okumura, a teenager who discovers that he and his twin brother Yukio are the sons of Satan, born from a human woman, and he is the inheritor of Satan's powers.",
                          "https://i.ebayimg.com/images/g/XvIAAOSwbgNgJS72/s-l1200.jpg")
            );
        }
    }
}