using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Entites
{
    public class Member
    {
        [Key]
        [Required(ErrorMessage = "Social number is required")]
        [Display(Name = "Person Number")]
        public string Id { get; set; } // here we will input personNumber


        [Required(ErrorMessage = "First Name is required")]
        [UniqueName(ErrorMessage = "First Name and Last Name cannot be the same.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [UniqueName(ErrorMessage = "First Name and Last Name cannot be the same.")]
        public string LastName { get; set; }

        public bool Membership { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        // Navigation property
        public ICollection<Ownership>? Ownerships { get; set; }//Declare this null we don't require ownership to create a new member 
    }
}

