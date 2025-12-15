using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectV2.Models
{
    public class TicketType
    {
        public int TicketTypeId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = "";

        [Range(0.01, 9999.99)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Range(0, 100000)]
        public int QuantityAvailable { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
    }
}

