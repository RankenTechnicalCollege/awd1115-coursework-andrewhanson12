using System.Collections.Generic;

namespace FinalProjectV2.Models.ViewModels
{
    public class EventDetailsVM
    {
        public Event Event { get; set; } = new Event();
        public IEnumerable<TicketType> TicketTypes { get; set; } = new List<TicketType>();
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}

