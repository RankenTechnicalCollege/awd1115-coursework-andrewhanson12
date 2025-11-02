using System;
using System.ComponentModel.DataAnnotations;

namespace HOT4.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date/Time")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndDate => StartDate.AddHours(1);

        [Required(ErrorMessage = "Customer is required")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}

