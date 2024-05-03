using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Vehicle
    {
        [Key]
        public string Id { get; set; }//RegisterNumber
        public string Color { get; set; }
        public string ModelType { get; set; }
        public string Brand { get; set; }

        // Navigation property
        public ICollection<Ownership> Ownerships { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
