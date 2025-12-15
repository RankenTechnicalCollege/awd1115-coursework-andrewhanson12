namespace FinalProject.Models.ViewModels
{
    public class EventsListViewModel
    {
        public List<Event> Events { get; set; } = new();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public string SearchTerm { get; set; } = "";
    }
}
