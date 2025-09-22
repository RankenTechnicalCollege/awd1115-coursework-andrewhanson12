using Microsoft.EntityFrameworkCore;
namespace HOT2.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Wheels" },
                new Category() { CategoryId = 2, CategoryName = "Accessories" },
                new Category() { CategoryId = 3, CategoryName = "Components" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, ProductName = "AeroFlo ATB Wheels", ProductImage = "", ProductDescLong = "", ProductDescShort = "", ProductPrice = 189, ProductQuantity = 40, CategoryId = 3 },
                new Product() { ProductId = 2, ProductName = "Clear Shade 85-T Glasses", ProductImage = "", ProductDescLong = "", ProductDescShort = "", ProductPrice = 45, ProductQuantity = 14, CategoryId = 2 },
                new Product() { ProductId = 3, ProductName = "Cosmic Elite Road Warrior Wheels", ProductImage = "", ProductDescLong = "", ProductDescShort = "", ProductPrice = 165, ProductQuantity = 22, CategoryId = 3 },
                new Product() { ProductId = 4, ProductName = "Cycle-Doc Pro Repair Stand", ProductImage = "", ProductDescLong = "", ProductDescShort = "", ProductPrice = 166, ProductQuantity = 12, CategoryId = 2 },
                new Product() { ProductId = 5, ProductName = "Dog Ear Aero-Flow Floor Pump", ProductImage = "", ProductDescLong = "", ProductDescShort = "", ProductPrice = 55, ProductQuantity = 25, CategoryId = 2 }
            );
        }
    }
}
