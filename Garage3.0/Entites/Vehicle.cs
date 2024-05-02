using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Vehicle
    {
        public string Color { get; set; }
        public string ModelType { get; set; }
        public string Brand { get; set; }
        public int MyProperty { get; set; }
        //public int VehicleTypeId { get; set; }
        //public VehicleType VehicleType { get; set; }

        [Key]
        public int Id { get; set; }

        // Foregin key
        [ForeignKey("RegisterNumber")]
        public int RegisterNumber { get; set; }
        public ICollection<Ownership> Ownerships { get; set; }

    }
}
