using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Entites
{
    public class Vehicle
    {
        public string RegisterNumber { get; set; }
        public string Color { get; set; }
        public string ModelType { get; set; }
        public string Brand { get; set; }
        public int MyProperty { get; set; }
        //public int VehicleTypeId { get; set; }
        //public VehicleType VehicleType { get; set; }
    }
}
