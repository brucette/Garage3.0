using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CheckOut { get; set; }
        public TimeSpan TotParkingTime { get; set; }
        public double Price { get; set; }

        //foregin key 
        public string VehicleId { get; set; }

        //Navigation property
        public Ownership Ownership { get; set; }
    }
}
