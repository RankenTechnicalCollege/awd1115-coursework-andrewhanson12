using System.ComponentModel.DataAnnotations;

namespace TripsLog.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Trip>? Trips { get; set; }
    }
}
