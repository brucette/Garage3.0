using System.ComponentModel.DataAnnotations;

namespace Garage3._0.ModelView
{
    public class AddVehicleModelView
    {
        [Required]
        public string RegisterNumber { get; set; }
        public string Color { get; set; }
        public string ModelType { get; set; }
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Vehicle Owners Personal Number")]
        public string OwnerPersonalNumber { get; set; } // Or Member ID

        //Add VehicleType Info here if you want?
        [Display(Name = "Type of Vehicle")]

        public int VehicleTypeId { get; set; }

    }
}
