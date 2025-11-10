using System.ComponentModel.DataAnnotations;

namespace RankenClassSchedule.Models.DomainModels
{
    public class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }
        public int TeacherId { get; set; }
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters.")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<Class> Classes { get; set; } 
    }
}
