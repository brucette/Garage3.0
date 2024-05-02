using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Ownership
    {
        // Foregin key
        [ForeignKey("Member")]
        public string PersonNumber { get; set; }

        // Foregin key
        //[ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public Member Member { get; set; }
        public Receipt Receipt { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
