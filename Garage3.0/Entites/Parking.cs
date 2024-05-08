using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Entites
{
    public class Parking
    {
        public int Id { get; set; }
        public int ParkingLotNumber { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Registration No.")]
        public string VehicleId { get; set; } // Foreign key

        // Navigation property 
        public Ownership? Ownership { get; set; }

        public Vehicle? Vehicle { get; set; }
    }
}
