using System.ComponentModel.DataAnnotations;

namespace FinalProjectV2.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string Status { get; set; } = "Placed";

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}

