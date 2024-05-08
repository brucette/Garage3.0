using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Vehicle
    {
        [Key]
        [Display(Name = "Registration Number")]
        public string Id { get; set; }//RegisterNumber
        public string Color { get; set; }
        [Display(Name = "Model Type")]
        public string ModelType { get; set; }
        public string Brand { get; set; }

        // Add foreign key for vehicletype
        [Display(Name = "Vehicle Id")]
        public int VehicleTypeId { get; set; }

        // Navigation property
        public ICollection<Ownership>? Ownerships { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
