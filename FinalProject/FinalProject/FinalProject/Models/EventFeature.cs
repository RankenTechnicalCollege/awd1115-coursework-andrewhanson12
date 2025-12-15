namespace FinalProject.Models
{
    public class EventFeature
    {
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public int FeatureId { get; set; }
        public Feature? Feature { get; set; }
    }
}

