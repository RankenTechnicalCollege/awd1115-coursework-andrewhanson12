using Microsoft.EntityFrameworkCore;

namespace HOT3.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                
                new Game
                {
                    Id = 1,
                    Name = "The Legend of Zelda: Breath of the Wild",
                    Genre = "Action",
                    Year = 2017,
                    Developer = "Nintendo",
                    Publisher = "Nintendo",
                    Price = 59.99m,
                    ImageFileName = "zelda_breath_of_the_wild.jpg"
                },
                new Game
                {
                    Id = 2,
                    Name = "God of War",
                    Genre = "Action",
                    Year = 2018,
                    Developer = "Santa Monica Studio",
                    Publisher = "Sony Interactive Entertainment",
                    Price = 49.99m,
                    ImageFileName = "god_of_war.jpg"
                },
                new Game
                {
                    Id = 3,
                    Name = "Red Dead Redemption 2",
                    Genre = "Action",
                    Year = 2018,
                    Developer = "Rockstar Games",
                    Publisher = "Rockstar Games",
                    Price = 59.99m,
                    ImageFileName = "red_dead_redemption_2.jpg"
                },
                new Game
                {
                    Id = 4,
                    Name = "The Witcher 3: Wild Hunt",
                    Genre = "RPG",
                    Year = 2015,
                    Developer = "CD Projekt Red",
                    Publisher = "CD Projekt",
                    Price = 39.99m,
                    ImageFileName = "witcher_3_wild_hunt.jpg"
                },
                new Game
                {
                    Id = 5,
                    Name = "Minecraft",
                    Genre = "Survival",
                    Year = 2011,
                    Developer = "Mojang Studios",
                    Publisher = "Mojang Studios",
                    Price = 26.95m,
                    ImageFileName = "minecraft.jpg"
                },
                new Game
                {
                    Id = 6,
                    Name = "NHL 26",
                    Genre = "Sports",
                    Year = 2025,
                    Developer = "EA Vancouver",
                    Publisher = "EA Sports",
                    Price = 69.99m,
                    ImageFileName = "nhl26.jpg"
                }
            );
        }
    }
}
