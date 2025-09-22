using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CH4.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = string.Empty;
        public string Slug => FirstName?.Replace(' ', '-').ToLower() + "-" + LastName?.Replace(' ', '-').ToLower();
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category? Category { get; set; }

    }
}
