using System.ComponentModel.DataAnnotations;

namespace TripsLog.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; } = string.Empty;
        [Required(ErrorMessage = "Accommodation is required")]
        public string Accommodation { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string? AccommodationPhone { get; set; }
        public string? AccommodationEmail { get; set; }
        public string? Activity1 { get; set; }
        public string? Activity2 { get; set; }
        public string? Activity3 { get; set; }
    }
}
