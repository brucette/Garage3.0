using System.ComponentModel.DataAnnotations;

namespace Garage3._0.ModelView
{
    public class AddVehicleModelView
    {
        // Kollar så att registerings nummret är 6 characters långt.
        [Required(ErrorMessage = "Register Number is required")]
        [RegularExpression(@"^[a-zA-Z0-9]{6}$", ErrorMessage = "Register Number must be 6 characters long and contain only letters and digits.")]
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
