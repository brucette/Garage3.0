using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Entites
{
    public class Member
    {
        [Key]
        [Required(ErrorMessage = "Social number is required")]
        [Display(Name = "Social Security No.")]
        [StringLength(12, ErrorMessage = "Social number has to be 12 digits.")]
        [RegularExpression("\\d{12}$", ErrorMessage = "Social number " +
            "must be in the format 'YYYYMMDD1234'.")]
        public string Id { get; set; } // here we will input personNumber


        [Required(ErrorMessage = "First Name is required")]
        [UniqueName(ErrorMessage = "First Name and Last Name cannot be the same.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [UniqueName(ErrorMessage = "First Name and Last Name cannot be the same.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool Membership { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Parked Vehicles")]
        public int NumberOfVehicles;

        // Navigation property
        public ICollection<Ownership>? Ownerships { get; set; } //Declare this null we don't require ownership to create a new member 
    }
}

