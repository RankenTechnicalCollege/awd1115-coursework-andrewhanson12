using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class TicketType
    {
        public int TicketTypeId { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; } = string.Empty;
        [Range(0, 999999)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
