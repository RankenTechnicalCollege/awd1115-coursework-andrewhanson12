using Microsoft.EntityFrameworkCore;

namespace HOT4.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>().HasIndex(a => a.StartDate).IsUnique();

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Username = "Alice", Phone = "123-456-7890" },
                new Customer { Id = 2, Username = "Bob", Phone = "987-654-3210" },
                new Customer { Id = 3, Username = "Charlie", Phone = "555-555-5555" }
            );
        }
    }
}
