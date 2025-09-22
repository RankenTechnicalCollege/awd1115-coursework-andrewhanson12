using Microsoft.EntityFrameworkCore;
namespace CH4.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public ContactContext(DbContextOptions<ContactContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1 , CategoryName = "Family" },
                new Category { CategoryId = 2 , CategoryName = "Friend" },
                new Category { CategoryId = 3 , CategoryName = "Work" }
            );
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Delores",
                    LastName = "Del Rio",
                    Email = "delores@hotmail.com",
                    Phone = "555-987-6543",
                    CategoryId = 2
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Efren",
                    LastName = "Herrara",
                    Email = "efren@aol.com",
                    Phone = "555-456-7890",
                    CategoryId = 3
                },            
                new Contact
                {
                    ContactId = 3,
                    FirstName = "Mary Ellen",
                    LastName = "Walton",
                    Email = "MaryEllen@yahoo.com",
                    Phone = "555-123-4567",
                    CategoryId = 1
                });
        }
    }
}
