using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Entites
{
    public class Member
    {
        [Key]
        public string Id { get; set; } // here we will input personNumber

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public bool Membership { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        // Navigation property
        public ICollection<Ownership> Ownerships { get; set; }
    }
}
