using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Ownership
    {
        public string MemberId { get; set; }
        public string VehicleId { get; set; }

        [Display(Name = "Person Number")]
        public Member Member { get; set; }
        public Vehicle Vehicle { get; set; }

        public ICollection<Receipt> Receipts { get; set; } // Navigation property can have one-to many relationship
        public ICollection<Parking> Parkings { get; set; } // Navigation property
    }
}
