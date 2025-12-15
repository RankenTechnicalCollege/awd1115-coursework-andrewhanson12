namespace FinalProject.Models.ViewModels
{
    public class EventDetailsViewModel
    {
        public Event Event { get; set; } = new Event();

        public List<TicketType> TicketTypes { get; set; } = new List<TicketType>();

        public List<string> FeatureNames { get; set; } = new List<string>();
    }
}
