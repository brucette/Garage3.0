using Garage3._0.Entites;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.ModelView
{
    public class MemberDetailsViewModel
    {
        [Display(Name = "Social Security No.")]
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool Membership { get; set; }

        [Display(Name = "Vehicles")]
        public int NumberOfVehicles { get; set; }

        public ICollection<Ownership> Ownerships { get; set; }
    }
}
