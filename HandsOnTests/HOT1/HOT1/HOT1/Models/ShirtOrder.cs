using System.ComponentModel.DataAnnotations;

namespace HOT1.Models
{
    public class ShirtOrder
    {
        [Required(ErrorMessage = "Please enter a quantity.")]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1.")]

        public double? Quantity { get; set; }
        public string? DiscountCode { get; set; }

        public string GetDiscount()
        {
            if (DiscountCode == "6175")
            {
                return "30% Discount Applied";
            }
            else if (DiscountCode == "1390")
            {
                return "20% Discount Applied";
            }
            else if (DiscountCode == "BB88")
            {
                return "10% Discount Applied";
            }
            else
            {
                return "No Discount";
            }
        }

        public double CalculateSubTotal()
        {
            const double pricePerShirt = 15;
            double totalPrice = (Quantity ?? 0) * pricePerShirt;
            double discountPrice = totalPrice;
            if (!string.IsNullOrEmpty(DiscountCode) && DiscountCode.ToUpper() == "6175")
            {
                discountPrice *= 0.30; 
                totalPrice -= discountPrice;
            }
            if (!string.IsNullOrEmpty(DiscountCode) && DiscountCode.ToUpper() == "1390")
            {
                discountPrice *= 0.20;
                totalPrice -= discountPrice;
            }
            if (!string.IsNullOrEmpty(DiscountCode) && DiscountCode.ToUpper() == "BB88")
            {
                discountPrice *= 0.10;
                totalPrice -= discountPrice;
            }
            return totalPrice;
        }
        public double CalculateTax()
        {
            const double taxRate = 0.08;
            return CalculateSubTotal() * taxRate;
        }
        public double CalculateTotal()
        {
            return CalculateSubTotal() + CalculateTax();
        }
    }
}
