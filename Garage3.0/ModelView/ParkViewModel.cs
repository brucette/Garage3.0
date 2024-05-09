using Garage3._0.Entites;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.ModelView
{
    public class ParkViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Parking Lot")]
        public int ParkingLotNumber { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Registration No.")]
        public string VehicleId { get; set; }

        [Display(Name = "Owner")]
        public string OwnerName { get; set; }
        
        [Display(Name = "Type")]
        public string Type { get; set; }

        // Navigation property 
        public Ownership? Ownership { get; set; }

        public Vehicle? Vehicle { get; set; }
    }
}
