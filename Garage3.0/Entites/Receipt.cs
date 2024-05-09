using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Receipt
    {
        [Display(Name = "Person Number")]
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CheckOut { get; set; }
        public TimeSpan TotParkingTime { get; set; }
        public double Price { get; set; }
        public string VehicleId { get; set; }

        //Navigation property
        public Ownership? Ownership { get; set; }
    }
}
