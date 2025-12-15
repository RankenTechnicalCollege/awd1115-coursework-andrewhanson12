using System.ComponentModel.DataAnnotations;

namespace FinalProjectV2.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; } = "";

        [Required, StringLength(60)]
        public string Slug { get; set; } = "";

        public ICollection<EventTag> EventTags { get; set; } = new List<EventTag>();
    }
}

