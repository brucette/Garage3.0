using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Entites
{
    public class Member
    {
        [Key]
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Membership { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        // something here e.g. 
        // public ICollection<Ownership> Ownerships { get; set; }
        public ICollection<Ownership> Ownerships { get; set; }
    }
}
