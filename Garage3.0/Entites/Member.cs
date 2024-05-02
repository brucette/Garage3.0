using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Entites
{
    public class Member
    {
        [Key]
        public string PersonNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Membership { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Ownership> Ownerships { get; set; }
    }
}
