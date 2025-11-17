using System.ComponentModel.DataAnnotations;

namespace TripsLog.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        [Required(ErrorMessage = "Destination is required")]
        public int DestinationId { get; set; }
        public Destination Destination { get; set; } = null!;
        [Required(ErrorMessage = "Accommodation is required")]
        public int AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; } = null!;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public ICollection<TripActivity>? TripActivities { get; set; }
    }
}
