using System.ComponentModel.DataAnnotations;

namespace HOT1.Models
{
    public class ConvertDistance
    {
        [Required(ErrorMessage = "Please enter a value in inches.")]
        [Range(0.001, double.MaxValue, ErrorMessage = "Please enter a positive number.")]
        public double? Inches {  get; set; }

        public double ConvertToCm()
        {
            return (Inches ?? 0) * 2.54;
        }
    }
}
