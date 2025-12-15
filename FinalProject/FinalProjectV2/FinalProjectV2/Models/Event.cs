using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace FinalProjectV2.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; } = "";

        [Required, StringLength(120)]
        public string Location { get; set; } = "";

        [Required]
        public DateTime StartDate { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
        public string Slug { get; set; } = "";

        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();

        public ICollection<EventTag> EventTags { get; set; } = new List<EventTag>();
    }
}

