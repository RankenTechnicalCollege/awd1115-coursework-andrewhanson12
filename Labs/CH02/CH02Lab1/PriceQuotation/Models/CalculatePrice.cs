namespace PriceQuotation.Models
{
    public class CalculatePrice
    {
        public decimal Subtotal { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal CalculateDiscountAmount()
        {
            return Subtotal * (DiscountPercent / 100);
        }
        public decimal CalculateTotal()
        {
            return Subtotal - CalculateDiscountAmount();
        }
    }
}
