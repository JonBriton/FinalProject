using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Customer
    {
        public int CustomerID {get; set;}
        [Display(Name = "First Name")]
        [Required]
        public string FirstName {get; set;} = string.Empty;
        [Display(Name = "Last Name")]
        [Required]
        public string LastName {get; set;} = string.Empty;
        [Display(Name = "Age")]
        [Required]
        public int Age {get; set;}
        [Display(Name = "Gender")]
        [Required]
        public string Gender {get; set;} = string.Empty;
        [Display(Name = "State")]
        [Required]
        public string State {get; set;} = string.Empty;
        public List<Order>? Orders {get; set;} = default!; // Navigation Property. Student can have MANY StudentCourses

    }
}