using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }

        public DateTime? CheckoutTime { get; set; }

        public TimeSpan? TotalParkingTime { get; set; }
        public double Price { get; set; }

        // Foregin key
        //[ForeignKey("RegisterNumber")]
        //public string RegisterNumberEntity { get; set; }

        public ICollection<Ownership> Ownerships { get; set; }
    }
}
