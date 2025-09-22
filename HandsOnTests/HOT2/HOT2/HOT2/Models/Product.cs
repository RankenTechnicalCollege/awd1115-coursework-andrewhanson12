using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace HOT2.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a short description")]
        public string ProductDescShort { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a long description")]
        public string ProductDescLong { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter an image URL")]
        public string ProductImage { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a price")]
        [Range(1.00, 10000.00, ErrorMessage = "Price must be between 1.00 and 10000.00")]
        public decimal? ProductPrice { get; set; }

        [Required(ErrorMessage = "Please enter a quantity")]
        [Range(0, 1000, ErrorMessage = "Quantity must be between 0 and 10000")]
        public int? ProductQuantity { get; set; }
        public string Slug => (ProductName ?? string.Empty).ToLower().Replace(" ", "-");
        public int? CategoryId { get; set; }

        [ValidateNever]
        public Category? Category { get; set; }
    }
}
