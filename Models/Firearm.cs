using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Firearm
    {
        public int FirearmID {get; set;} // Primary Key
        [Required]
        public string Brand {get; set;} = string.Empty;
        [Required]
        public string Model {get; set;} = string.Empty;
        [Required]
        public string Caliber {get; set;} = string.Empty;
        [Required]
        public string Type {get; set;} = string.Empty;
        public List<Order> Orders {get; set;} = default!; // Navigation Property. Course can have MANY StudentCourses
    }

    public class Order
    {
        public int FirearmID {get; set;}     // Composite Primary Key, Foreign Key 1
        public int CustomerID {get; set;}    // Composite Primary Key, Foreign Key 2
        public Customer Customer {get; set;} = default!; // Navigation Property. One Student per StudentCourse
        public Firearm Firearm {get; set;} = default!;   // Navigation Property. One Course per StudentCourse
    }
}