using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectV2.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int TicketTypeId { get; set; }
        public TicketType? TicketType { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }
    }
}

