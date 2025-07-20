using Microsoft.EntityFrameworkCore;

namespace AnimeBookmarksV2.Models
{
    public class AnimeDbContext : DbContext
    {
        //Reverting back to oringal state nmisspell

        public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options) { }

        public DbSet<Animev2> Anime { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<AnimeGenre> AnimeGenres { get; set; }

        public DbSet<UserAccounts> Users { get; set; }

        public DbSet<UserBookmarks> Bookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserBookmarks>().HasOne(ub => ub.User).WithMany(u => u.Bookmarks)
                .HasForeignKey(ub => ub.AccountId);
                

            modelBuilder.Entity<UserBookmarks>().HasOne(ub => ub.Anime).WithMany()
                .HasForeignKey(ub => ub.AnimeId);

            modelBuilder.Entity <Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Comedy" },
                new Genre { Id = 4, Name = "Drama" },
                new Genre { Id = 5, Name = "Fantasy" },
                new Genre { Id = 6, Name = "Romance" },
                new Genre { Id = 7, Name = "Sports" }
                );

            modelBuilder.Entity<Animev2>().HasData(
                new Animev2
                {
                    Id = 1, Title = "Blue Exorcist",
                    Description = "The story revolves around Rin Okumura, a teenager who discovers that he and his twin brother Yukio are the sons of Satan, born from a human woman, and he is the inheritor of Satan's powers.",
                    AnimeLink = "https://www.crunchyroll.com/series/G649PJ0JY/blue-exorcist",
                    ImagePath = "/AnimeImages/s-l1200.jpg"
                },

                new Animev2
                {
                    Id = 2, Title = "BLUE LOCK",
                    Description = " Three hundred high school players are pitted against each other for the position, but only one will come out on top. Who among them will be the striker to usher in a new era of Japanese soccer?",
                    AnimeLink = "https://www.crunchyroll.com/series/G4PH0WEKE/blue-lock",
                    ImagePath = "/AnimeImages/blueLock.jpg"
                },

                new Animev2
                {
                    Id = 3, Title = "Yamada-kun and the Seven Witches",
                    Description = "Suzaku High School student and problem kid, Ryu Yamada, is in a bad mood after being chewed out again by the teacher today. As if his day couldn’t get any worse, he falls down the top of the stairs with honor student, Urara Shiraishi! When he comes to, he’s switched bodies with her!",
                    AnimeLink = "https://www.crunchyroll.com/series/G63VMKVQY/yamada-kun-and-the-seven-witches",
                    ImagePath = "/AnimeImages/sevenWitches.jpg"
                },

                new Animev2
                {
                    Id = 4, Title = "That Time I Got Reincarnation as a Slime",
                    Description = "Corporate worker Mikami Satoru is stabbed by a random killer, and is reborn to an alternate world. But he turns out to be reborn a slime!\r\nThrown into this new world with the name Rimuru, he begins his quest to create a world that’s welcoming to all races.",
                    AnimeLink = "https://www.crunchyroll.com/series/GYZJ43JMR/that-time-i-got-reincarnated-as-a-slime",
                    ImagePath = "/AnimeImages/reincarnationAsASlime.jpg"
                }
                );

            modelBuilder.Entity<AnimeGenre>()
             .HasKey(ag => new { ag.AnimeId, ag.GenreId });

            modelBuilder.Entity<AnimeGenre>().HasData(
                new AnimeGenre { AnimeId = 1, GenreId = 1 },
                new AnimeGenre { AnimeId = 1, GenreId = 2 },
                new AnimeGenre { AnimeId = 1, GenreId = 3 },
                new AnimeGenre { AnimeId = 1, GenreId = 5 },

                new AnimeGenre { AnimeId = 2, GenreId = 7 },
                new AnimeGenre { AnimeId = 2, GenreId = 4 },

                new AnimeGenre { AnimeId = 3, GenreId = 3 },
                new AnimeGenre { AnimeId = 3, GenreId = 4 },
                new AnimeGenre { AnimeId = 3, GenreId = 5 },
                new AnimeGenre { AnimeId = 3, GenreId = 6 },

                new AnimeGenre { AnimeId = 4, GenreId = 1 },
                new AnimeGenre { AnimeId = 4, GenreId = 2 },
                new AnimeGenre { AnimeId = 4, GenreId = 5 });


            modelBuilder.Entity<UserAccounts>().HasData(
                new UserAccounts
                {
                    AccountId = 1,
                    Username = "Admin_Creator",
                    Email = "admin@email.com",
                    Password = "password123",
                    Role = "Admin",
                },

                new UserAccounts
                {
                    AccountId = 2,
                    Username = "Guest",
                    Email = "guest@email.com",
                    Password =  "password123",
                    Role = "User",
                });

            modelBuilder.Entity<UserBookmarks>().HasData(
                new UserBookmarks { Id = 1, AccountId = 1, AnimeId = 1 },
                new UserBookmarks { Id = 2, AccountId = 1, AnimeId = 4});
        }

    }
}
