using FinalProjectV2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events => Set<Event>();
        public DbSet<TicketType> TicketTypes => Set<TicketType>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<EventTag> EventTags => Set<EventTag>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EventTag>().HasKey(et => new { et.EventId, et.TagId });
        }

    }
}
