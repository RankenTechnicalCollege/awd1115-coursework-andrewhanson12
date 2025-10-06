using System.ComponentModel.DataAnnotations;

namespace CH03Lab.Models
{
    public class CalculatePrice
    {
        [Required(ErrorMessage = "Please enter a sale price")]
        [Range(0.01, 10000000.00, ErrorMessage = "Sale price must be between 0.01 and 10,000.00")]
        public decimal? Subtotal { get; set; }
        [Required(ErrorMessage = "Please enter a discount percent")]
        [Range(0.01, 100.00, ErrorMessage = "Discount percent must be between 0.01 and 100.00")]
        public decimal? DiscountPercent { get; set; }
        public decimal CalculateDiscountAmount()
        {
            return (Subtotal ?? 0) * ((DiscountPercent ?? 0) / 100);
        }
        public decimal CalculateTotal()
        {
            return (Subtotal ?? 0) - CalculateDiscountAmount();
        }
    }
}
