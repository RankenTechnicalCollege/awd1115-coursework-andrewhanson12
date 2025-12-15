using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class StarlightContext : DbContext
    {
        public StarlightContext(DbContextOptions<StarlightContext> options)
            : base(options) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<TicketType> TicketTypes => Set<TicketType>();
        public DbSet<Feature> Features => Set<Feature>();
        public DbSet<EventFeature> EventFeatures => Set<EventFeature>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventFeature>()
                .HasKey(ef => new { ef.EventId, ef.FeatureId });

            modelBuilder.Entity<EventFeature>()
                .HasOne(ef => ef.Event)
                .WithMany(e => e.EventFeatures)
                .HasForeignKey(ef => ef.EventId);

            modelBuilder.Entity<EventFeature>()
                .HasOne(ef => ef.Feature)
                .WithMany(f => f.EventFeatures)
                .HasForeignKey(ef => ef.FeatureId);
        }
    }
}
