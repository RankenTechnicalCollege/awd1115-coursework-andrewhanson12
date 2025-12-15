using System.Collections.Generic;

namespace FinalProjectV2.Models.ViewModels
{
    public class EventListVM
    {
        public IEnumerable<Event> Events { get; set; } = new List<Event>();
        public string SearchTerm { get; set; } = "";
    }
}


