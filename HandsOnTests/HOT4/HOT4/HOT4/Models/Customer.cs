using System.ComponentModel.DataAnnotations;

namespace HOT4.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;
        public List<Appointment>? Appointments { get; set; }
    }
}
