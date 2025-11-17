using Microsoft.EntityFrameworkCore;

namespace TripsLog.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<Destination> Destinations { get; set; } = null!;
        public DbSet<Accommodation> Accommodations { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<TripActivity> TripActivities { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite key for the join table
            modelBuilder.Entity<TripActivity>()
                .HasKey(ta => new { ta.TripId, ta.ActivityId });

            modelBuilder.Entity<Destination>().HasData(
                new Destination { DestinationId = 1, Name = "Green Bay, Wisconsin" },
                new Destination { DestinationId = 2, Name = "New York, New York" },
                new Destination { DestinationId = 3, Name = "Tampa Bay, Florida" }
            );
            modelBuilder.Entity<Accommodation>().HasData(
                new Accommodation
                {
                    AccommodationId = 1,
                    Name = "Hotel",
                    Phone = "555-555-5555",
                    Email = "hotel@hotel.com"
                },
                new Accommodation
                {
                    AccommodationId = 2,
                    Name = "Staybridge Suites",
                    Phone = "212-555-1234",
                    Email = "staff@staybridge.com"
                },
                new Accommodation
                {
                    AccommodationId = 3,
                    Name = "Camping",
                    Phone = null,
                    Email = null
                }
            );
            modelBuilder.Entity<Activity>().HasData(
                new Activity { ActivityId = 1, Name = "Football Game" },
                new Activity { ActivityId = 2, Name = "Beach" },
                new Activity { ActivityId = 3, Name = "Hiking" },
                new Activity { ActivityId = 4, Name = "Museum" },
                new Activity { ActivityId = 5, Name = "Swimming" },
                new Activity { ActivityId = 6, Name = "Restaurant" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
