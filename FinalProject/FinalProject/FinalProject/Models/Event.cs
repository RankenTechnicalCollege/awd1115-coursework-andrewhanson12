using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace FinalProject.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; } = DateTime.Today;

        [Required]
        [StringLength(120)]
        public string Location { get; set; } = string.Empty;

        [Range(0, 999999)]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }
        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
        public ICollection<EventFeature> EventFeatures { get; set; } = new List<EventFeature>();
        public string Slug
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Title)) return "event";
                string s = Title.Trim().ToLower();
                s = Regex.Replace(s, @"[^a-z0-9\s-]", "");   
                s = Regex.Replace(s, @"\s+", "-");          
                s = Regex.Replace(s, "-{2,}", "-");         
                return s;
            }
        }
    }
}

