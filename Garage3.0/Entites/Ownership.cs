using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Ownership
    {
        public string MemberId { get; set; }
        [Key]
        public int Id { get; set; }
        public string RegisterNumber { get; set; }

        // Foregin key
        [ForeignKey("PersonNumber")]
        public string PersonNumberEntity { get; set; }
        // Foregin key
        [ForeignKey("RegisterNumber")]
        public string RegisterNumberEntity { get; set; }

        public Member Member { get; set; }
        public Receipt Receipt { get; set; }
        public Vehicle Vehicle { get; set; }
        public VehicleType VehicleType { get; set; }

    }
}
